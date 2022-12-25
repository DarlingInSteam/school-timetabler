using System.Collections.Generic;using System.Collections.ObjectModel;using System.Reactive;using Data.Repositories;using Domain.Entities;using Domain.UseCases;using MessageBox.Avalonia;using ReactiveUI;using ReactiveUI.Fody.Helpers;namespace SchoolTimetabler.ViewModels;public class TeacherEditingMenuViewModel : ViewModelBase, IRoutableViewModel, IScreen{    [Reactive] public int DataGridSelectedIndex { get; set; }    [Reactive] public bool IsEnableNext { get; set; } = true;    [Reactive] public bool IsVisibleAddDiscipline { get; set; }    [Reactive] public bool IsVisibleAddTeacher { get; set; } = true;    [Reactive] public bool IsVisibleDataGrid { get; set; } = true;    [Reactive] public string TeacherName { get; set; }    private int _selectedIndexCheckBox;    [Reactive] public List<string> SelectedIndexListBox { get; set; }    [Reactive] public int SelectedIndexTeacherDisciplines { get; set; }    private readonly TeacherInteractor _teacherInteractor;    public TeacherEditingMenuViewModel(CreateSchoolProfileViewModel createSchoolProfileViewModel)    {        DisciplinesName = new ObservableCollection<string>();        DisciplinesTeacher = new ObservableCollection<string>();        TeachersName = new ObservableCollection<string>();        SelectedIndexListBox = new List<string>();        _teacherInteractor = new TeacherInteractor(TeacherRepository.GetInstance());        var disciplineInteractor = new DisciplineInteractor(DisciplineRepository.GetInstance());        Teachers = new ObservableCollection<Teacher>(_teacherInteractor.GetTeachers());        Disciplines = new ObservableCollection<Discipline>(disciplineInteractor.GetDisciplines());        AddDesciplineToTeacher = ReactiveCommand.Create(() =>        {            _teacherInteractor.AddDiscipline(SelectedIndexListBox, _selectedIndexCheckBox);            Teachers.Clear();            TeachersName.Clear();            foreach (var t in _teacherInteractor.GetTeachers())            {                Teachers.Add(t);                TeachersName.Add(t.TeacherFullName);            }        });        Back = ReactiveCommand.Create(() =>        {            IsVisibleDataGrid = true;            IsVisibleAddTeacher = true;            IsVisibleAddDiscipline = false;            IsEnableNext = true;        });        DeleteTeacherDiscipline = ReactiveCommand.Create(() =>        {            _teacherInteractor.DeleteDiscipline(SelectedIndexTeacherDisciplines, _selectedIndexCheckBox);            DisciplinesTeacher.Clear();            foreach (var t in _teacherInteractor.GetTeacherDisciplines(_selectedIndexCheckBox))                DisciplinesTeacher.Add(t);        });        AddDescipline = ReactiveCommand.Create(() =>        {            DisciplinesName.Clear();            TeachersName.Clear();            foreach (var t in Disciplines) DisciplinesName.Add(t.DisciplineName);            foreach (var t in Teachers) TeachersName.Add(t.TeacherFullName);            IsVisibleDataGrid = false;            IsVisibleAddTeacher = false;            IsVisibleAddDiscipline = true;            IsEnableNext = false;        });        AddNewTeacher = ReactiveCommand.Create(() =>        {            _teacherInteractor.AddTeacher(TeacherName);            Teachers.Clear();            foreach (var t in _teacherInteractor.GetTeachers()) Teachers.Add(t);        });        DeleteTeacher = ReactiveCommand.Create(() =>        {            _teacherInteractor.DeleteTeacher(Teachers[DataGridSelectedIndex]);            Teachers.Remove(Teachers[DataGridSelectedIndex]);        });    }    public ObservableCollection<Teacher> Teachers { get; set; }    public ObservableCollection<Discipline> Disciplines { get; set; }    public ObservableCollection<string> DisciplinesName { get; set; }    public ObservableCollection<string> TeachersName { get; set; }    public ObservableCollection<string> DisciplinesTeacher { get; set; }    public ReactiveCommand<Unit, Unit> DeleteTeacherDiscipline { get; }    public ReactiveCommand<Unit, Unit> Back { get; }    public ReactiveCommand<Unit, Unit> AddDesciplineToTeacher { get; }    public ReactiveCommand<Unit, Unit> AddNewTeacher { get; }    public ReactiveCommand<Unit, Unit> DeleteTeacher { get; }    public ReactiveCommand<Unit, Unit> AddDescipline { get; }    private bool _isVisibleDisciplineInfo = false;    private void Update()    {        var t = _teacherInteractor.GetTeacherDisciplines(_selectedIndexCheckBox);        if (t.Count != 0)        {            DisciplinesTeacher.Clear();            foreach (var di in t) DisciplinesTeacher.Add(di);        }    }    public int SelectedIndexCheckBox    {        get => _selectedIndexCheckBox;        set        {            this.RaiseAndSetIfChanged(ref _selectedIndexCheckBox, value);            Update();        }    }    public string? UrlPathSegment { get; }    public IScreen HostScreen { get; }    public RoutingState Router { get; }}