using UnityEngine;

namespace Lesson
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class MyFirstMod : MonoBehaviour
    {
        private readonly int _windowId = Random.Range(1000, 2000000);

        private Rect _windowRect = new Rect(100, 100, 100, 80);

        void Awake()
        {
            RenderingManager.AddToPostDrawQueue(_windowId, WindowOnDraw);
        }

        private void WindowOnDraw()
        {
            _windowRect = GUI.Window(_windowId, _windowRect, WindowOnGui, "First window", HighLogic.Skin.window);
        }

        //onJointBreak - разрушение соединения
        //onCrash - корабль разрушен
        //onCrashSplashdown - разрушен при спуске на воду
        //onCollision - столкновение с объектом
        //onOverheat - перегрев двигателя
        //onStageSeparation - разделение ступеней
        //onLaunch - запуск корабля
        //onUndock - расстыковка
        //onSplashDamage - 
        //onNewVesselCreated - новый корабль создан игрой
        //onVesselWillDestroy - корабль будет уничтожен
        //onVesselCreate - корабль создан на основе конфига
        //onVesselDestroy - корабль разрушен (выгрузка из памяти при смене сцены, например, или полное уничтожение при падении)
        //onVesselChange - смена активного корабля
        //onVesselSituationChange - изменение статуса корабля (полет - посадка, к примеру)
        //onKnowledgeChanged 
        //onVesselRename - корабль переименован
        //onVesselGoOnRails
        //onVesselGoOffRails
        //onVesselLoaded - корабль загружен из конфига
        //onVesselWasModified - модификация корабля (например отвалилась или взорвалась какая-то часть)
        //onVesselSOIChanged
        //onVesselOrbitClosed
        //onVesselOrbitEscaped - корабль покинул орбиту
        //OnVesselRecoveryRequested
        //onVesselRecovered - корабль восстановлен (recover vessel command)
        //onVesselTerminated
        //onSameVesselDock
        //onSameVesselUndock
        //onStageActivate - активация ступени
        //onDominantBodyChange - смена доминирующей планеты (например, при гравитационном перехвате в полете)
        //onKrakensbaneEngage
        //onKrakensbaneDisengage
        //onFloatingOriginShift
        //onRotatingFrameTransition
        //onGamePause - игра поставлена на паузу
        //onGameUnpause - снята пауза игры
        //onFlightReady 
        //onTimeWarpRateChanged - изменилось ускорение времени
        //onGameSceneLoadRequested - поступил запрос на смену сцены (например из стартовой площадки в редактор)
        //onLevelWasLoaded - уровень загружен
        //onPlanetariumTargetChanged - смена цели (выделенного объекта) в tracking station
        //onGameStateSaved - игра сохранена
        //onGameStateCreated - создано сохранение 
        //onGameStateSave - игра сохраняется (будет сохранена)
        //onGameStateLoad - игра загружена
        //onInputLocksModified - изменена блокировка пользовательского ввода (например запрещен staging)
        //OnGameSettingsApplied - применены настройки игры
        //onPartPack - часть упакована
        //onPartUnpack - часть распакована
        //onPartExplode - часть взорвана
        //onPartDie - часть уничтожена (недоступна)
        //onPartDestroyed - часть выгружена из памяти
        //onPartJointBreak - разрушение соединения части
        //onPartUndock - часть отстыкована
        //onPartCouple - часть присоединена
        //onPartAttach - часть присоединена в редакторе
        //onPartRemove - часть удалена (в редакторе)
        //onPartActionUICreate
        //onPartActionUIDismiss
        //onCrewTransferred - перемещение команды
        //onCrewOnEva - выход кербала в EVA режим
        //onCrewKilled - команда уничтожена
        //onKerbalAdded
        //onKerbalRemoved
        //onCrewBoardVessel - кербал залез в корабль
        //onKerbalTypeChange 
        //onKerbalStatusChange
        //onFlagSelect - выбран флаг
        //onMissionFlagSelect
        //onFlagPlant - развернут флаг
        //onActiveJointNeedUpdate
        //onGUILaunchScreenSpawn
        //onGUILaunchScreenDespawn
        //onGUILaunchScreenVesselSelected
        //onGUIAstronautComplexSpawn
        //onGUIAstronautComplexDespawn
        //onGUIRnDComplexSpawn
        //onGUIRnDComplexDespawn
        //onGUIMissionControlSpawn
        //onGUIMissionControlDespawn
        //onGUIAdministrationFacilitySpawn
        //onGUIAdministrationFacilityDespawn
        //onGUIRecoveryDialogSpawn
        //onGUIRecoveryDialogDespawn
        //onHideUI - спрятали UI по F2
        //onShowUI  - показали UI по F2
        //onGUIPrefabLauncherReady
        //onGUIApplicationLauncherReady
        //onGUIApplicationLauncherUnreadifying
        //onGUIApplicationLauncherDestroyed
        //onGUIMessageSystemReady
        //onEditorShipModified - изменился корабль в редакторе
        //OnTechnologyResearched - исследовали технологию
        //OnPartPurchased - часть куплена в редакторе
        //OnVesselRollout
        //OnProgressReached
        //OnProgressComplete
        //OnProgressAchieved
        //OnScienceRecieved
        //OnReputationChanged
        //OnScienceChanged
        //OnFundsChanged
        //onVesselRecoveryProcessing
        //OnKSCStructureCollapsing - здание разрушается
        //OnKSCStructureCollapsed - здание разрушено
        //OnKSCStructureRepairing - здание восстанавливается
        //OnKSCStructureRepaired - здание восстановлено



        private void WindowOnGui(int id)
        {
            GUILayout.BeginVertical(GUILayout.ExpandHeight(true));

            GUILayout.BeginHorizontal();

            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Attach Event", GUILayout.ExpandWidth(true)))
            {
                //добавляем подписку на события
                GameEvents.onLaunch.Add(OnLaunch);
                GameEvents.onCrewOnEva.Add(OnEva);
            }

            GUILayout.FlexibleSpace();

            GUILayout.EndHorizontal();

            GUILayout.EndVertical();

            GUI.DragWindow();
        }

        private void OnEva(GameEvents.FromToAction<Part, Part> data)
        {
            PopupDialog.SpawnPopupDialog("Information", "Kerbal go to EVA!", "Ok", false, HighLogic.Skin);
        }

        private void OnLaunch(EventReport data)
        {
            PopupDialog.SpawnPopupDialog("Information", "Vessel has launched!", "Ok", false, HighLogic.Skin);
        }

        void OnDestroy()
        {
            Debug.Log("[MyFirstMod] Call OnDestroy");

            RenderingManager.RemoveFromPostDrawQueue(_windowId, WindowOnDraw);

            //удаляем подписку на события
            GameEvents.onLaunch.Remove(OnLaunch);
            GameEvents.onCrewOnEva.Remove(OnEva);
        }

    }
}


