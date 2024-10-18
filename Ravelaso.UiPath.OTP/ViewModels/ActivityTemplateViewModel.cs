using System.Activities.DesignViewModels;

namespace Ravelaso.UiPath.OTP.ViewModels
{
    public class ActivityTemplateViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<string> Secret { get; set; }
        public DesignOutArgument<string> Result { get; set; }

        public ActivityTemplateViewModel(IDesignServices services) : base(services)
        {
        }
        
        protected override void InitializeModel()
        {
            base.InitializeModel();

            // Initialize default values if necessary
            Secret = new DesignInArgument<string> { IsRequired = true };
            Result = new DesignOutArgument<string>();

            // mandatory call only when you change the values of properties during initialization
            PersistValuesChangedDuringInit(); 
        }
    }
}