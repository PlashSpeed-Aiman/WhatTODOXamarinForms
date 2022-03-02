using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using App2.Commands;
using App2.Model;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Formatting = System.Xml.Formatting;

namespace App2.ViewModel
{
    public class TodoViewModel : BaseViewModel
    {
        private string _title;
        private bool _isCompleted = false;
        private string _description;
        private ObservableCollection<Todo> _todos;
        private ICommand _SubmitCommand;
        private ICommand _SaveCommand;
        public ICommand DeleteCommand { get; }
        public TodoViewModel()
        {
            /*string text = System.IO.File.ReadAllText($"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/file_json.json");
            var list = JsonConvert.DeserializeObject<IList<Todo>>(text);*/
            _todos = new ObservableCollection<Todo>();
            /*foreach(var item in list)
            {
                _todos.Add(item);
            }*/
            DeleteCommand = new Command<Todo>(DeleteItem);
        }

        public bool IsCompleted { get { return _isCompleted; } set { _isCompleted = value; OnPropertyChanged(); } }
        public string Title { get { return _title; } set { _title = value; OnPropertyChanged(); } }

        public string DescriptionT { get { return _description; } set { _description = value; OnPropertyChanged(); } }

        /* public Todo todo()
         {
             return new Todo
             {
                 Title = Title,
                 Description = DescriptionT,
                 Created = DateTime.Now,
                 isActive = IsCompleted
             };

         }*/
        public void DeleteItem(object Todo)
        {
            var todoToDelet = Todo as Todo;
            if (todoToDelet != null)
                todos.Remove(todoToDelet);
            Trace.WriteLine(todos.Count);
        }
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new RelayCommand(param => this.WriteToJSON(todos),
                        null);
                }
                return _SaveCommand;
            }
        }
        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(param => this.Submit(),
                        null);
                }
                return _SubmitCommand;
            }
        }
        public ObservableCollection<Todo> todos
        {
            get { return _todos; }
            set
            {
                this._todos = value;
                base.OnPropertyChanged();
            }
        }

        private async Task WriteToJSON(IList<Todo> todos)
        {
            var json_File = JsonConvert.SerializeObject(todos);
            await Task.Run(() => File.WriteAllText($"{FileSystem.AppDataDirectory}/file_json.json", json_File));
        }
        Todo selectedTodo;
        public Todo Test
        {
            get => selectedTodo;
            set
            {
                if (value != null)
                {
                    if (value.Description != null)
                    {
                        Application.Current.MainPage.DisplayAlert("TODO Description", value.Description, "OK");
                        value = null;
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("TODO Description", "Nothing was described", "OK");
                        value = null;
                    }
                }

                selectedTodo = value;
                OnPropertyChanged();
            }

        }
        public Command<Todo> DeteleCommand
        {
            get
            {
                return new Command<Todo>((x) =>
               {
                   todos.Remove(x);
               });
            }
        }
        private async void Submit()
        {
            await Task.Run(() =>
            {
                var newTodo = new Todo
                {
                    Title = Title,
                    Description = DescriptionT,
                    Created = DateTime.Now.ToString("d"),
                    isActive = IsCompleted
                };
                todos.Add(newTodo);
            });
            
            /*            Trace.WriteLine(newTodo.ToString());
            */
        }
    }
}