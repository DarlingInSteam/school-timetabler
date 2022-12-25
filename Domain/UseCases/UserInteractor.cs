using Domain.Entities;using Domain.Repositories;using MessageBox.Avalonia;namespace Domain.UseCases;public class UserInteractor{    private readonly IUserRepository<User> _userRepository;    public UserInteractor(IUserRepository<User> userRepository)    {        _userRepository = userRepository;    }    public void UserSet(string post, string userName)    {        if (string.IsNullOrWhiteSpace(post) || string.IsNullOrWhiteSpace(userName))        {            if (string.IsNullOrWhiteSpace(post) && string.IsNullOrWhiteSpace(userName) == false)            {                var message = MessageBoxManager                    .GetMessageBoxStandardWindow("Неправильные данные",                        "Вы не заполинили одно или несколько полей в информации о пользователе: Должность").Show();            }            if (string.IsNullOrWhiteSpace(userName) && string.IsNullOrWhiteSpace(post) == false)            {                var message = MessageBoxManager                    .GetMessageBoxStandardWindow("Неправильные данные",                        "Вы не заполинили одно или несколько полей в информации о пользователе: ФИО редактора").Show();            }            if (string.IsNullOrWhiteSpace(userName) && string.IsNullOrWhiteSpace(post))            {                var message = MessageBoxManager                    .GetMessageBoxStandardWindow("Неправильные данные",                        "Вы не заполинили одно или несколько полей в информации о пользователе: ФИО редактора, Должность")                    .Show();            }        }        else        {            _userRepository.Add(new User(userName, post));        }    }    public User UserGet()    {        var info = _userRepository.Read();        return info;    }    public void SchoolInfoDel()    {        _userRepository.Delete();    }}