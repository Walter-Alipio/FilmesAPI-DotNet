using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FilmesAPI.Authorization
{
  public class IdadeMinimaHandler : AuthorizationHandler<IdadeMinimaRequired>
  {
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinimaRequired requirement)
    {
      if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
        return Task.CompletedTask;

      DateTime dataNascimento = Convert.ToDateTime(
        context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth
      ).Value);

      int idadeObtida = DateTime.Today.Year - dataNascimento.Year;
      //caso a pessoa ainda não tenha feito aniversario

      if (dataNascimento > DateTime.Today.AddYears(-idadeObtida))
        idadeObtida--;

      if (idadeObtida >= requirement.IdadeMinima) context.Succeed(requirement);

      return Task.CompletedTask;
    }
  }
}