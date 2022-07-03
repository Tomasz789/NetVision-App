using NetVision.AppWindows;
using NetVision.DataCore.Model;
using NetVision.Infrastructure.Services;
using NetVision.MVRelayCmds;
using NetVision.ViewModel.PropertyUpdater;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetVision.ViewModel
{
    public class HttpViewModel : ViewModelPropertyUpdater
    {
        private IHttpClientService _clientService;
        private HttpResponseModel _response;
        private IList<HttpResponseModel> _list;
        public HttpViewModel()
        {
            _clientService = new HttpClientService();
            _response = new HttpResponseModel();
            _list = new List<HttpResponseModel>();
            GetRequestCmd = new RelayCommand(GetValue, CanExecute);
        }
        public string Url
        {
            get
            {
                return _response.Url;
            }
            set
            {
                _response.Url = value;
                OnPropertyChanged("Url");
            }
        }
        public int ResponseId
        {
            get
            {
                return _response.ResponseId;
            }
            set
            {
                _response.ResponseId = value;
                OnPropertyChanged("ResId");
            }
        }
        public string Value
        {
            get
            {
                return _response.TextValue;
            }
            set
            {
                _response.TextValue = value;
                OnPropertyChanged("Value");
            }
        }
        public string Status
        {
            get
            {
                return _response.Status;
            }
            set
            {
                _response.Status = value;
                OnPropertyChanged("Status");
            }
        }

        public string Content
        {
            get
            {
                return _response.Content;
            }
            set
            {
                _response.Content = value;
                OnPropertyChanged("Content");
            }
        }

        public string TextValue
        {
            get
            {
                return _response.TextValue;
            }
            set
            {
                _response.TextValue = value;
                OnPropertyChanged("TextValue");
            }
        }

        public string Method
        {
            get
            {
                return _response.Method;
            }
            set
            {
                _response.Method = value;
                OnPropertyChanged("Method");
            }
        }

        public HttpResponseModel Model
        {
            get
            {
                return _response;
            }
            set
            {
                _response = value;
                OnPropertyChanged("ResponseModel");
            }
        }
        public IList<HttpResponseModel> HttpResponses
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
                OnPropertyChanged("List");
            }
        }
        public ICommand GetRequestCmd { get; set; }

        private bool CanExecute(object param)
        {
            return true;
        }

        private async Task ExecuteRequest()
        {
            switch(_response.Method)
            {
                case "GET":
                    _response = await _clientService.GetRequestAsync(_response.Url);
                     break;
                case "POST":
                    await _clientService.PostReqestAsync(_response.Url, _response.Content);
                     break;
                case "DELETE":
                    await _clientService.DeleteAsync(_response.Url);
                    break;
                case "PUT":
                    await _clientService.PutRequestAsync(_response.Url, _response.Content);
                    break;
            }

            await Task.CompletedTask;
          
        }
        public async void GetValue(object parameter)
        {
            await ExecuteRequest();
            await Task.CompletedTask;
        }

    }
}
