using H5_Webshop.Authorization;
using H5_Webshop.Database.Entities;
using H5_Webshop.Repositories;
using H5_Webshop.DTOs;

namespace H5_Webshop.Services
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAll();
        // Task<List<UserResponse>> GetAdmins();
        Task<UserResponse> GetById(int UserId);
        Task<LoginResponse> Authenticate(LoginRequest login);
        Task<UserResponse> Register(UserRequest newUser);
        Task<GuestResponse> Register_Guest(GuestRequest newUser);
        Task<UserResponse> Update(int UserId, UserRequest updateUser);
        Task<UserResponse> Delete(int UserId);

    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtUtils _jwtUtils;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;

        }




        public async Task<List<UserResponse>> GetAll()
        {

            List<User> users = await _userRepository.GetAll();


            return users == null ? null : users.Select(u => new UserResponse
            {
                Id = u.UserId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Address = u.Address,
                Telephone  = u.Telephone,
                Email = u.Email,
                Password = u.Password,
                Role = u.Role
            }).ToList();


        }




        public async Task<UserResponse> Register(UserRequest newuser)
        {
            User user = new User
            {

                FirstName = newuser.FirstName,
                
                LastName = newuser.LastName,
                Address = newuser.Address,
                Telephone = newuser.Telephone,
                Email = newuser.Email,
                Password = newuser.Password,
                Role = Helpers.Role.Member// force all users created through Register, to Role.User
            };

            user = await _userRepository.Create(user);

            return MapUserToUserResponse(user);
        }

        public async Task<UserResponse> GetById(int UserId)
        {
            User User = await _userRepository.GetById(UserId);

            if (User != null)
            {

                return MapUserToUserResponse(User);
            }
            return null;
        }

        public async Task<LoginResponse> Authenticate(LoginRequest login)
        {

            User user = await _userRepository.GetByEmail(login.Email);
            if (user == null)
            {
                return null;
            }

            if (user.Password == login.Password)
            {
                LoginResponse response = new LoginResponse
                {
                    Id = user.UserId,
                    Email = user.Email,
                    FirstName = user.FirstName,
             
                    Password = user.Password,
                    Role = user.Role,
                    Token = _jwtUtils.GenerateJwtToken(user)
                };
                return response;
            }

            return null;
        }
        public async Task<UserResponse> Update(int UserId, UserRequest updateUser)
        {
            User user = new User
            {
                FirstName = updateUser.FirstName,
               
                LastName = updateUser.LastName,
                Address = updateUser.Address,
                Telephone = updateUser.Telephone,
                Email = updateUser.Email,
                Password = updateUser.Password,

            };

            user = await _userRepository.Update(UserId, user);

            return user == null ? null : new UserResponse
            {
                Id = user.UserId,
                FirstName = user.FirstName,
                
                LastName = user.LastName,
                Address=user.Address,
                Telephone=user.Telephone,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
        }

        public async Task<UserResponse> Delete(int userId)

        {
            User user = await _userRepository.Delete(userId);

            if (user != null)
            {
                return MapUserToUserResponse(user);
            }

            return null;
        }


        private static UserResponse MapUserToUserResponse(User user)
        {

            return user == null ? null : new UserResponse
            {
                Id = user.UserId,
                Email = user.Email,
                FirstName = user.FirstName,
               
                LastName = user.LastName,
                Address = user.Address,
                Telephone = user.Telephone,
                Password = user.Password,
                Role = user.Role

            };

        }
        private static GuestResponse MapGuestToGuestResponse(User user)
        {

            return user == null ? null : new GuestResponse
            {
                Id = user.UserId,
                Email = user.Email,
                FirstName = user.FirstName,

                LastName = user.LastName,
                Address = user.Address,
                Telephone = user.Telephone,
                
                Role = user.Role

            };

        }

        public async Task<GuestResponse> Register_Guest(GuestRequest gstUser)
        {
            User user = new User
            {

                FirstName = gstUser.FirstName,

                LastName = gstUser.LastName,
                Address = gstUser.Address,
                Telephone = gstUser.Telephone,
                Email = gstUser.Email,
                Password = "No Need",
                Role = Helpers.Role.Member// force all users created through Register, to Role.User
            };

            user = await _userRepository.Create(user);

            return MapGuestToGuestResponse(user);
        }
    }
    
}
