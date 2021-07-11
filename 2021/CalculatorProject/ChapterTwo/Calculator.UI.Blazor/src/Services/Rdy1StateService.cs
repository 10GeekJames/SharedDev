using System;
using Calculator.Models.ViewModels;

namespace Calculator.UI.Blazor.Services
{
    public class CalculatorStateService
    {
        private ActiveBusinessDataVM _activeBusinessDataVM;
        private ActiveUserDataVM _activeUserDataVM;
        public ActiveBusinessDataVM ActiveBusinessData
        {
            get => _activeBusinessDataVM;
            set
            {
                _activeBusinessDataVM = value;
                NotifyStateChanged();
            }
        }
        public ActiveUserDataVM ActiveUserData
        {
            get => _activeUserDataVM;
            set
            {
                _activeUserDataVM = value;
                NotifyStateChanged();
            }
        }
        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}