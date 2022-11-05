using System;using ReactiveUI;using Avalonia.schoolTimetabler.Models;namespace Avalonia.schoolTimetabler.ViewModels{    public class CreateSchoolProfileViewModel : ViewModelBase, IRoutableViewModel    {        private string? _schoolNumber;        private string? _countClasses;        private string? _fullNameDirector;                private string? _fullName;        private string? _post;        public CreateSchoolProfileViewModel(MainWindowViewModel mainWindowViewModel)        {                    }        public CreateSchoolProfileViewModel()        {                    }        public void ConfirmSchoolSettings()        {            if (_schoolNumber == null || _fullNameDirector == null || _countClasses == null) return;            var confirm = new School(_schoolNumber, _fullNameDirector, _countClasses);        }                public void ConfirmUserSettings()        {            if (_post == null || _fullName == null) return;            var confirm = new User(_fullName, _post);        }        public string? FullName        {            set            {                if (value != null && !string.Equals(value, ""))                {                    this.RaiseAndSetIfChanged(ref _fullName, value);                }            }            get            {                if (_fullName != null)                    return _fullName;                throw new NullReferenceException();            }        }                public string? Post        {            set            {                if (value != null && !string.Equals(value, ""))                {                    this.RaiseAndSetIfChanged(ref _post, value);                }            }            get            {                if (_post != null)                    return _post;                throw new NullReferenceException();            }        }                public string? SchoolNumber        {            set            {                if (value != null && !string.Equals(value, ""))                {                    this.RaiseAndSetIfChanged(ref _schoolNumber, value);                }            }            get            {                if (_schoolNumber != null)                    return _schoolNumber;                                throw new NullReferenceException();            }        }        public string? FullNameDirector        {            set            {                if (value != null && !string.Equals(value, ""))                {                    this.RaiseAndSetIfChanged(ref _fullNameDirector, value);                }            }            get            {                if (_fullNameDirector != null)                    return _fullNameDirector;                                throw new NullReferenceException();            }        }                public string? CountClasses        {            set            {                if (value != null && !string.Equals(value, ""))                {                    this.RaiseAndSetIfChanged(ref _countClasses, value);                }            }            get            {                if (_countClasses != null)                    return _countClasses;                                throw new NullReferenceException();            }        }                public string? UrlPathSegment { get; }        public IScreen HostScreen { get; }    }}