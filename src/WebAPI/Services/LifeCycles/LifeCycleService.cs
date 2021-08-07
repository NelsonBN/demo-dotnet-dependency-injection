namespace WebAPI.Services.LifeCycles
{
    public class LifeCycleService
    {
        private readonly ITransientService _transientService;
        private readonly IScopedService _scopedService;
        private readonly ISingletonService _singletonService;
        private readonly ISingletonInstanceService _singletonInstanceService;

        public LifeCycleService(
            ITransientService transientService,
            IScopedService scopedService,
            ISingletonService singletonService,
            ISingletonInstanceService singletonInstanceService
        )
        {
            this._transientService = transientService;
            this._scopedService = scopedService;
            this._singletonService = singletonService;
            this._singletonInstanceService = singletonInstanceService;
        }

        public string GetInstantiationDetails()
        {
            return
                $"\t{this._transientService.GetInstantiationDetails()}" +
                $"{System.Environment.NewLine}" +
                $"\t{this._scopedService.GetInstantiationDetails()}" +
                $"{System.Environment.NewLine}" +
                $"\t{this._singletonService.GetInstantiationDetails()}" +
                $"{System.Environment.NewLine}" +
                $"\t{this._singletonInstanceService.GetInstantiationDetails()}";
        }
    }
}