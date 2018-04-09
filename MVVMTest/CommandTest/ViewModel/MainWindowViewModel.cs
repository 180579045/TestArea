using System;
using System.Windows;
using MyMVVM;

namespace CommandTest.ViewModel
{
    class MainWindowViewModel : NotifyObject
    {

        private bool _canExecute;
        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                _canExecute = value;
                RaisePropertyChanged("CanExecute");
            }
        }

        /// <summary>
        /// 这是一个正常的按钮，不带任何参数和触发条件;
        /// </summary>
        private MyCommand _normalCommand;
        public MyCommand NormalCommand
        {
            get
            {
                // 初始化的时候，将对应的处理注册给MyCommand
                if(_normalCommand == null)
                    _normalCommand = new MyCommand(
                        new Action<object>(o => MessageBox.Show("这是个普通命令!"))
                        );

                return _normalCommand;
            }
        }

        /// <summary>
        /// 这是一个带条件判断的命令绑定;
        /// </summary>
        private MyCommand _canExecuteCommand;
        public MyCommand CanExecuteCommand
        {
            get
            {
                // 初始化的时候，将对应的处理与条件注册给MyCommand
                if (_canExecuteCommand == null)
                    _canExecuteCommand = new MyCommand(
                        new Action<object>(o => MessageBox.Show("命令可以执行！")),
                        new Func<object, bool>(o => CanExecute)
                        );

                return _canExecuteCommand;
            }
        }

        /// <summary>
        /// 这是一个带参数的命令绑定;
        /// </summary>
        private MyCommand _paramCommand;
        public MyCommand ParamCommand
        {
            get
            {
                if (_paramCommand == null)
                    _paramCommand = new MyCommand(
                        new Action<object>(
                            o => MessageBox.Show(o.ToString())),
                        new Func<object, bool>(
                            o => !string.IsNullOrEmpty(o.ToString())));
                return _paramCommand;
            }
        }
    }
}
