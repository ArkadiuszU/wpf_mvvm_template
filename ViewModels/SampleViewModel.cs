using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_MVVM_Template.Models;
using WPF_MVVM_Template.ViewModels.HelpersVM;

namespace WPF_MVVM_Template.ViewModels
{
    class SampleViewModel : BaseViewModel
    {
        private SampleModel model = new SampleModel { Text = "Enter some text", Value = 0 };

        public ObservableCollection<SampleItemViewModel> ItemsList { get; set; } = new ObservableCollection<SampleItemViewModel>();

        public SampleViewModel()
        {
            ItemsList.Add(new SampleItemViewModel { Title = "Aa", Id = 1 });
            ItemsList.Add(new SampleItemViewModel { Title = "Bb", Id = 2 });
            ItemsList.Add(new SampleItemViewModel { Title = "Cc", Id = 3 });
            ItemsList.Add(new SampleItemViewModel { Title = "Dd", Id = 4 });
            ItemsList.Add(new SampleItemViewModel { Title = "Ee", Id = 5 });

        }
        private ICommand resetComand;
        private ICommand changeProgressCommand;


        public int ProgressValue { 
            get
            {
                return model.Value; 
            }
            set
            {
                model.Value = value;
                onPropertyChanged(nameof(ProgressValue));
            } 
        }
        public string InputText
        {
            get
            {
                return model.Text;
            }
            set
            {
                model.Text = value;
                onPropertyChanged(nameof(InputText));
            }
        }

        public ICommand Reset
        {
            get 
            {
                if(resetComand == null) { resetComand = new RelayCommand(
                        (object o) => 
                        { 
                            model.Value = 0;
                            onPropertyChanged(nameof(ProgressValue));
                        }, 
                        (object o) => 
                        {
                            return model.Value > 0;
                        }
                    );
                }
                return resetComand;
            }
        }

         public ICommand ChangeProgress
        {
            get 
            {
                if(changeProgressCommand == null) {
                    changeProgressCommand = new RelayCommand(
                        (object o) => 
                        {
                            model.Value = Convert.ToInt32(o);
                            ItemsList.Add(new SampleItemViewModel { Title = "Dd", Id = 4 });
                 
                            onPropertyChanged(nameof(ProgressValue));
                        }
                    );
                }
                return changeProgressCommand;
            }
        }


    }
}
