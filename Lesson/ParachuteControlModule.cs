using System.Linq;

namespace Lesson
{
    [KSPModule("My first module")]
    public class ParachuteControlModule : PartModule
    {
        private bool _isStart = false;

        [KSPField(guiActive = true, guiActiveEditor = true, category = "My", guiName = "Parachute control", isPersistant = true)]
        [UI_Toggle(controlEnabled = true, enabledText = "On", disabledText = "Off", scene = UI_Scene.Editor)]
        public bool IsOn = false;


        [KSPField(guiActive = true, guiActiveEditor = true, category = "My", guiName = "Parachute altitude", guiUnits = "meters", guiFormat = "####", isPersistant = true)]
        [UI_FloatRange(controlEnabled = true, minValue = 0, maxValue = 5000, scene = UI_Scene.Editor, stepIncrement = 5)]
        public float StartAltitude = 0;

        public override string GetInfo()
        {
            return "Advanced parachute control module.";
        }

        /// <summary>
        /// вызывается при активации модуля после его старта
        /// </summary>
        public override void OnActive()
        {
            base.OnActive();
        }

        /// <summary>
        //вызывается один раз при создании модуля
        /// </summary>
        public override void OnAwake()
        {
            base.OnAwake();
        }

        /// <summary>
        /// вызывается через фиксированный промежуток времени (не везде работает)
        /// </summary>
        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
        }

        /// <summary>
        /// вызывается при деактивации модуля (когда деактивируется part)
        /// </summary>
        public override void OnInactive()
        {
            base.OnInactive();
        }

        /// <summary>
        /// вызывается при инициализации модуля (например в редакторе или при загрузке корабля). вызывается не всегда!!!
        /// </summary>
        public override void OnInitialize()
        {
            base.OnInitialize();
        }

        /// <summary>
        /// загрузка модуля из сохранения
        /// </summary>
        /// <param name="node"></param>
        public override void OnLoad(ConfigNode node)
        {
            base.OnLoad(node);
        }

        /// <summary>
        /// сохранение модуля (сохранение игры)
        /// </summary>
        /// <param name="node"></param>
        public override void OnSave(ConfigNode node)
        {
            base.OnSave(node);
        }

        /// <summary>
        /// старт модуля (когда активируется part)
        /// </summary>
        /// <param name="state"></param>
        public override void OnStart(StartState state)
        {
            base.OnStart(state);
        }

        /// <summary>
        /// вызывается циклически максимальное количество раз в секунду (при отрисовке кадра). зависит от нагрузки и FPS
        /// </summary>
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (!IsOn || !HighLogic.LoadedSceneIsFlight) return;

            //высота растет
            if (vessel.verticalSpeed > 0)
            {
                return;
            }
            
            //начали снижение
            if (vessel.altitude <= StartAltitude && vessel.situation == Vessel.Situations.FLYING && !_isStart)
            {
                //получаем все модули парашюта
                var parachuteModules = part.Modules.OfType<ModuleParachute>().ToList();

                if (parachuteModules.Any())
                {
                    //раскрываем каждый парашют
                    parachuteModules.ForEach(x => x.Deploy());
                }

                _isStart = true;
            }
        }


    }
}


