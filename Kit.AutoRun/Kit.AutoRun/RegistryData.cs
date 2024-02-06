using Microsoft.Win32;

namespace Kit.AutoRun
{
    public class RegistryData
    {
        private const string userRoot = "HKEY_CURRENT_USER";
        public const string KIT_SET_ICON = "KIT_SET_ICON";
        public const string KIT_OPTIOPN_SEND = "KIT_OPTIOPN_SEND";        
        public const string KIT_SET_DELAY = "KIT_SET_DELAY";
       
        public const string KIT_SET_FUNCTION_INDEX = "KIT_SET_FUNCTION_INDEX";
        public const string KIT_SET_SPECIAL_VALUE = "KIT_SET_SPECIAL_VALUE";
        public const string KIT_ICON_SIZE = "KIT_ICON_SIZE";
        public const string KIT_ENABLE_RUN = "KIT_ENABLE_RUN";
        public const string KIT_APP_NAME = userRoot + "\\" + "KIT.AUTORUN";

        public static object Select(string strKey)
        {
            return Registry.GetValue(KIT_APP_NAME, strKey, null);
        }

        public static object Select(string strKey, object objDefault)
        {
            try
            {
                object objResult = Registry.GetValue(KIT_APP_NAME, strKey, objDefault);
                if (objResult == null)
                {
                    Registry.SetValue(KIT_APP_NAME, strKey, objDefault);
                    return objDefault;
                }
                else
                    return objResult;
            }
            catch
            {
                Registry.SetValue(KIT_APP_NAME, strKey, objDefault);
                return Registry.GetValue(KIT_APP_NAME, strKey, objDefault);
            }
        }

        public static void Update(string strKey, object objValue)
        {
            Registry.SetValue(KIT_APP_NAME, strKey, objValue);
        }
    }
}
