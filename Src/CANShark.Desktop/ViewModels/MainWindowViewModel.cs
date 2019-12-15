﻿using CANShark.Desktop.ViewModels.Core;
using CANShark.Desktop.ViewModels.Data;
using CANShark.Desktop.ViewModels.Modal;
using ReactiveUI;
using Serilog;
using System.Reactive;

namespace CANShark.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ILogger _logger;
        private readonly SetupMenuViewModel _setupMenuViewModel;
        private readonly AboutViewModel _aboutViewModel;
        private readonly CommandsViewModel _commandsViewModel;

        public MainWindowViewModel(
            ILogger logger,
            SetupMenuViewModel setupMenuViewModel,
            AboutViewModel aboutViewModel,
            CommandsViewModel commandsViewModel)
        {
            _logger = logger;
            _setupMenuViewModel = setupMenuViewModel;
            _aboutViewModel = aboutViewModel;
            _commandsViewModel = commandsViewModel;


            Content = _commandsViewModel;

            ShowAboutModal = ReactiveCommand.Create(() =>
            {
                Modal = _aboutViewModel;
            });

            ShowSetupMenuModal = ReactiveCommand.Create(() =>
            {
                _logger.Information("Setup window");
                Modal = _setupMenuViewModel;
            });

            CloseModal = ReactiveCommand.Create(() =>
            {
                Modal = null;
            });
        }

        public ViewModelBase Content { get; set; }

        public ViewModelBase Modal { get; set; }

        public ReactiveCommand<Unit, Unit> ShowAboutModal { get; }

        public ReactiveCommand<Unit, Unit> ShowSetupMenuModal { get; }

        public ReactiveCommand<Unit, Unit> CloseModal { get; }
    }
}
