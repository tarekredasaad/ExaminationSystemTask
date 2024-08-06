using Domain.Interfaces.UnitOfWork;
using Infrastructure;
using Infrastructure.UnitOfWork;

namespace DynamicAuthApi.Middlewaare
{
    public class TransactionMiddleware
    {

        RequestDelegate _next;
        Context _context;
        //UnitOfWork _unitOfWork;
        public TransactionMiddleware(RequestDelegate next
            //UnitOfWork unitOfWork
            //, Context context
            )
        {
            _next = next;
            //_unitOfWork = unitOfWork;
            //_context = context;
        }

        public async Task InvokeAsync(HttpContext httpContext,Context unitOfWork)
        {
            var method = httpContext.Request.Method.ToUpper();
            if (method == "POST" || method == "PUT" || method == "DELETE")
            {
                var transaction = unitOfWork.Database.BeginTransaction();

                try
                {
                    await _next(httpContext);
                    await unitOfWork.SaveChangesAsync();
                    await  transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                  await  transaction?.RollbackAsync();
                    throw;
                }
            }
            else
            {
                await _next(httpContext);
            }
        }

    }
}
