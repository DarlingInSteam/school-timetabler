using System.Collections.Generic;using System.Reactive;using Data.Repositories;using Data.Repository;using Domain.Entities;using Domain.UseCases;using MessageBox.Avalonia;using ReactiveUI;namespace SchoolTimetabler.ViewModels;public class CreateSchoolProfileViewModel : ViewModelBase, IRoutableViewModel, IScreen{    private string _borderFullName = "White";    private string _countClasses;    private string _countTeachers;    private string _fullName;    private string _fullNameDirector;    private string _post;    private string _schoolNumber;    private readonly UserInteractor _userInteractor;    private readonly SchoolInfoInteractor _schoolInfoInteractor;    public CreateSchoolProfileViewModel()    {        _userInteractor = new UserInteractor(UserRepository.GetInstance());        _schoolInfoInteractor = new SchoolInfoInteractor(SchoolRepository.GetInstance());        ConfirmSchoolSettings = ReactiveCommand.Create(() =>        {            _schoolInfoInteractor.SchoolInfoSet(_fullNameDirector, _countClasses, _countTeachers, _schoolNumber);        });        ConfirmUserSettings = ReactiveCommand.Create(() =>        {            _userInteractor.UserSet(_post, _fullName);        });        GoToСabinetEditingMenu = ReactiveCommand.CreateFromObservable(            () => Router.Navigate.Execute(                new CabinetEditingMenuViewModel())        );        GoToDisciplineEditingMenu = ReactiveCommand.CreateFromObservable(            () => Router.Navigate.Execute(                new DisciplineEditingMenuViewModel(this))        );        GoToClassEditingMenu = ReactiveCommand.CreateFromObservable(            () => Router.Navigate.Execute(                new ClassEditingMenuViewModel(this))        );        GoToTeacherEditingMenu = ReactiveCommand.CreateFromObservable(            () => Router.Navigate.Execute(                new TeacherEditingMenuViewModel(this))        );    }    public ReactiveCommand<Unit, IRoutableViewModel> GoToClassEditingMenu { get; }    public ReactiveCommand<Unit, IRoutableViewModel> GoToDisciplineEditingMenu { get; }    public ReactiveCommand<Unit, IRoutableViewModel> GoToTeacherEditingMenu { get; }    public ReactiveCommand<Unit, IRoutableViewModel> GoToСabinetEditingMenu { get; }    public ReactiveCommand<Unit, Unit> ConfirmUserSettings { get; }    public ReactiveCommand<Unit, Unit> ConfirmSchoolSettings { get; }    public string FullName    {        set => this.RaiseAndSetIfChanged(ref _fullName, value);        get => _fullName;    }    public string BorderFullName    {        set => this.RaiseAndSetIfChanged(ref _borderFullName, value);        get => _borderFullName;    }    public string Post    {        set => this.RaiseAndSetIfChanged(ref _post, value);        get => _post;    }    public string SchoolNumber    {        set => this.RaiseAndSetIfChanged(ref _schoolNumber, value);        get => _schoolNumber;    }    public string FullNameDirector    {        set => this.RaiseAndSetIfChanged(ref _fullNameDirector, value);        get => _fullNameDirector;    }    public string CountClasses    {        set => this.RaiseAndSetIfChanged(ref _countClasses, value);        get => _countClasses;    }    public string CountTeachers    {        set => this.RaiseAndSetIfChanged(ref _countTeachers, value);        get => _countTeachers;    }    public string? UrlPathSegment { get; }    public IScreen HostScreen { get; }    public RoutingState Router { get; } = new();}