//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace TwitterFacade
//{
//    public class TweetSearchEventManager : WeakEventManager
//    {
       
//            public static PropertyValueChangedEventManager CurrentManager
//            {
//                get
//                {
//                    var manager_type = typeof(PropertyValueChangedEventManager);
//                    var manager = WeakEventManager.GetCurrentManager(manager_type) as PropertyValueChangedEventManager;

//                    if (manager == null)
//                    {
//                        manager = new PropertyValueChangedEventManager();
//                        WeakEventManager.SetCurrentManager(manager_type, manager);
//                    }

//                    return manager;
//                }
//            }

//            public static void AddListener(PropertyValue source, IWeakEventListener listener)
//            {
//                CurrentManager.ProtectedAddListener(source, listener);
//                return;
//            }

//            public static void RemoveListener(PropertyValue source, IWeakEventListener listener)
//            {
//                CurrentManager.ProtectedRemoveListener(source, listener);
//                return;
//            }

//            protected override void StartListening(object source)
//            {
//                ((PropertyValue)source).Changed += mHandler;
//                return;
//            }

//            protected override void StopListening(object source)
//            {
//                ((PropertyValue)source).Changed -= mHandler;
//                return;
//            }

//            private EventHandler mHandler = (s, e) =>
//            {
//                CurrentManager.DeliverEvent(s, e);
//                return;
//            };
        
//    }
//}
