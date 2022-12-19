using Domain.Entities;using Domain.Repositories;namespace Domain.UseCases;public class UserInteractor{    private readonly IUserRepository<User> _userRepository;        public UserInteractor(IUserRepository<User> userRepository)    {        _userRepository = userRepository;    }        public void UserSet(User user)    {        _userRepository.Add(user);    }    public User UserGet()    {        var info = _userRepository.Read();        return info;    }    public void SchoolInfoDel()    {        _userRepository.Delete();    }}