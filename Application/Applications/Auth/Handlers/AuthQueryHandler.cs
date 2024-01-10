using Applications.Auth.Queries;
using Domain;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MediatR;
using System.Net;

namespace Applications.Auth.Handlers
{
    public class AuthQueryHandler : IRequestHandler<AuthQuery, Response>
    {
        private readonly IResponse _response;
        private readonly IUserRepository _userRepository;
        private readonly IAccessManagerService _accessManagerService;

        public AuthQueryHandler(IResponse response, IUserRepository userRepository, IAccessManagerService accessManagerService)
        {
            _response = response;
            this._userRepository = userRepository;
            this._accessManagerService = accessManagerService;
        }

        public async Task<Response> Handle(AuthQuery request, CancellationToken cancellationToken)
        {

            if (request is null && String.IsNullOrEmpty(request.Login))
               return await _response.CreateErrorResponseAsync();

            if (String.IsNullOrEmpty(request.Password))
                return await _response.CreateErrorResponseAsync();

            var user = await _userRepository.FindByLoginAsync(request.Login, request.Password);

            if (user is null)
               return await _response.CreateErrorResponseAsync(HttpStatusCode.Unauthorized);


            var token = _accessManagerService.GenerateToken(user);

            return await _response.CreateSuccessResponseAsync(token, string.Empty);

            }


    }
}
