using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.ViewModels
{
    public class DirectoryItemViewModel : ViewModelBase
    {
        private static readonly DirectoryItemViewModel _dummyChild = new DirectoryItemViewModel();

        private DirectoryItemViewModel _parent;
        public DirectoryItemViewModel Parent
        {
            get => _parent;
        }

        private ObservableCollection<DirectoryItemViewModel> _children;
        public ObservableCollection<DirectoryItemViewModel> Children
        {
            get => _children;
        }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    OnPropertyChanged(nameof(IsExpanded));
                }

                if (_isExpanded && !(_parent is null))
                {
                    Parent.IsExpanded = true;
                }

                if (HasDummyChild)
                {
                    Children.Remove(_dummyChild);
                    LoadChildren();
                }
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public bool HasDummyChild
        {
            get => Children.Count == 1 && Children[0] == _dummyChild;
        }

        private DirectoryItemViewModel()
        {
        }

        public DirectoryItemViewModel(DirectoryItemViewModel parent, bool lazyLoadChildren)
        {
            _parent = parent;
            _children = new ObservableCollection<DirectoryItemViewModel>();

            if (lazyLoadChildren) 
            {
                _children.Add(_dummyChild);
            }
        }

        protected virtual void LoadChildren()
        {
            /*
             * TODO: 계층구조 검색 쿼리 실행 필요
             * 
             */
        }
    }
}
