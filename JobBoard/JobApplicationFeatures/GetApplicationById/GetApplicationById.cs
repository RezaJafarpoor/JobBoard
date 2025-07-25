using JobBoard.Infrastructure.Auth;
using JobBoard.JobApplicationFeatures.Mapper;
using JobBoard.JobApplicationFeatures.Services;
using JobBoard.Shared.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.JobApplicationFeatures.GetApplication;

public class GetApplicationById : IEndpointMarker
{
    public RouteHandlerBuilder Register(IEndpointRouteBuilder app)
        => app.MapGroup("api")
        .MapGet("applications/{applicationId}", async ([FromRoute] Guid applicationId, JobApplicationService service,
         CancellationToken cancellationToken) =>
        {
            var response = await service.GetApplicationById(applicationId, cancellationToken);
            return response.IsSuccess ?
             Results.Ok(JobApplicationMapper.MapToApplicationDto(response.Data)) :
             Results.NotFound(response.Errors);
        })
        .WithTags("Application")
        .WithDescription("دریافت رزومه با ایدی ")
        .WithSummary("Get applicaiton by id")
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .RequireAuthorization(AuthPolicy.EmployeeOnly);
}
