using System;
using PubNubAPI;
using NUnit.Framework;
using System.Text;
using System.Collections.Generic;

namespace PubNubAPI.Tests
{
    [TestFixture]
    public class PushBuildRequestsTests
    {
        #if DEBUG    
        [Test]
        public void TestBuildRegisterDevicePushRequestAPNS ()
        {
            TestBuildRegisterDevicePushRequestCommon (true, "", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void TestBuildRegisterDevicePushRequestMPNS ()
        {
            TestBuildRegisterDevicePushRequestCommon (true, "", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void TestBuildRegisterDevicePushRequestGCM ()
        {
            TestBuildRegisterDevicePushRequestCommon (true, "", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void TestBuildRegisterDevicePushRequestAPNSAuth ()
        {
            TestBuildRegisterDevicePushRequestCommon (true, "authKey", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void TestBuildRegisterDevicePushRequestMPNSAuth ()
        {
            TestBuildRegisterDevicePushRequestCommon (true, "authKey", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void TestBuildRegisterDevicePushRequestGCMAuth ()
        {
            TestBuildRegisterDevicePushRequestCommon (true, "authKey", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void TestBuildRegisterDevicePushRequestSSLAPNS ()
        {
            TestBuildRegisterDevicePushRequestCommon (false, "", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void TestBuildRegisterDevicePushRequestSSLMPNS ()
        {
            TestBuildRegisterDevicePushRequestCommon (false, "", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void TestBuildRegisterDevicePushRequestSSLGCM ()
        {
            TestBuildRegisterDevicePushRequestCommon (false, "", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void TestBuildRegisterDevicePushRequestSSLAPNSAuth ()
        {
            TestBuildRegisterDevicePushRequestCommon (false, "authKey", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void TestBuildRegisterDevicePushRequestSSLMPNSAuth ()
        {
            TestBuildRegisterDevicePushRequestCommon (false, "authKey", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void TestBuildRegisterDevicePushRequestSSLGCMAuth ()
        {
            TestBuildRegisterDevicePushRequestCommon (false, "authKey", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void TestBuildRegisterDevicePushRequestSSLGCMAuthQP ()
        {
            TestBuildRegisterDevicePushRequestCommon (false, "authKey", "pushToken", PNPushType.GCM, true);
        }

        public void TestBuildRegisterDevicePushRequestCommon(bool ssl, string authKey, string pushToken, PNPushType pushType){
            TestBuildRegisterDevicePushRequestCommon(ssl, authKey, pushToken, pushType, false);
        }

        public void TestBuildRegisterDevicePushRequestCommon(bool ssl, string authKey, string pushToken, PNPushType pushType, bool sendQueryParams){
            string channel = "push_channel";
            string uuid = "customuuid";
            Dictionary<string,string> queryParams = new Dictionary<string, string>();
            string queryParamString = "";
            if(sendQueryParams){
                queryParams.Add("d","f");
                queryParamString="&d=f";
            } else {
                queryParams = null;
            }


            PNConfiguration pnConfiguration = new PNConfiguration ();
            pnConfiguration.Origin = EditorCommon.Origin;
            pnConfiguration.SubscribeKey = EditorCommon.SubscribeKey;
            pnConfiguration.PublishKey = EditorCommon.PublishKey;
            pnConfiguration.Secure = ssl;
            pnConfiguration.CipherKey = "enigma";
            pnConfiguration.LogVerbosity = PNLogVerbosity.BODY; 
            pnConfiguration.PresenceTimeout = 60;
            pnConfiguration.PresenceInterval= 30;
            pnConfiguration.UUID = uuid;
            pnConfiguration.AuthKey = authKey;

            PubNubUnity pnUnity = new PubNubUnity(pnConfiguration, null, null);

            string authKeyString = "";
            if (!string.IsNullOrEmpty(authKey)) {
                authKeyString = string.Format ("&auth={0}", pnConfiguration.AuthKey);
            }

            Uri uri = BuildRequests.BuildRegisterDevicePushRequest (channel, pushType, pushToken, pnUnity, queryParams); 

            //[1, "Modified Channels"]
            //https://ps.pndsn.com/v1/push/sub-key/demo-36/devices/pushToken?add=push_channel&type=apns&uuid=customuuid&pnsdk=PubNub-CSharp-UnityIOS/3.6.9.0
            string expected = string.Format ("http{0}://{1}/v1/push/sub-key/{2}/devices/{3}?add={4}&type={5}&uuid={6}{7}&pnsdk={8}{9}",
                ssl?"s":"", pnConfiguration.Origin, EditorCommon.SubscribeKey, pushToken, 
                Utility.EncodeUricomponent(channel, PNOperationType.PNAddPushNotificationsOnChannelsOperation, true, false), pushType.ToString().ToLower(),
                uuid, authKeyString, 
                Utility.EncodeUricomponent(pnUnity.Version, PNOperationType.PNAddPushNotificationsOnChannelsOperation, false, true),
                queryParamString
            );
            string received = uri.OriginalString;
            UnityEngine.Debug.Log("exp:"+expected);
            UnityEngine.Debug.Log(received);
            EditorCommon.LogAndCompare (expected, received);
        }

        [Test]
        public void TestBuildRemoveChannelPushRequestAPNS ()
        {
            TestBuildRemoveChannelPushRequestCommon (true, "", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void TestBuildRemoveChannelPushRequestMPNS ()
        {
            TestBuildRemoveChannelPushRequestCommon (true, "", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void TestBuildRemoveChannelPushRequestGCM ()
        {
            TestBuildRemoveChannelPushRequestCommon (true, "", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void TestBuildRemoveChannelPushRequestAPNSAuth ()
        {
            TestBuildRemoveChannelPushRequestCommon (true, "authKey", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void TestBuildRemoveChannelPushRequestMPNSAuth ()
        {
            TestBuildRemoveChannelPushRequestCommon (true, "authKey", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void TestBuildRemoveChannelPushRequestGCMAuth ()
        {
            TestBuildRemoveChannelPushRequestCommon (true, "authKey", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void TestBuildRemoveChannelPushRequestSSLAPNS ()
        {
            TestBuildRemoveChannelPushRequestCommon (false, "", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void TestBuildRemoveChannelPushRequestSSLMPNS ()
        {
            TestBuildRemoveChannelPushRequestCommon (false, "", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void TestBuildRemoveChannelPushRequestSSLGCM ()
        {
            TestBuildRemoveChannelPushRequestCommon (false, "", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void TestBuildRemoveChannelPushRequestSSLAPNSAuth ()
        {
            TestBuildRemoveChannelPushRequestCommon (false, "authKey", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void TestBuildRemoveChannelPushRequestSSLMPNSAuth ()
        {
            TestBuildRemoveChannelPushRequestCommon (false, "authKey", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void TestBuildRemoveChannelPushRequestSSLGCMAuth ()
        {
            TestBuildRemoveChannelPushRequestCommon (false, "authKey", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void TestBuildRemoveChannelPushRequestSSLGCMAuthQP ()
        {
            TestBuildRemoveChannelPushRequestCommon (false, "authKey", "pushToken", PNPushType.GCM, true);
        }

        public void TestBuildRemoveChannelPushRequestCommon(bool ssl, string authKey, string pushToken, PNPushType pushType){
            TestBuildRemoveChannelPushRequestCommon(ssl, authKey, pushToken, pushType, false);
        }

        public void TestBuildRemoveChannelPushRequestCommon(bool ssl, string authKey, string pushToken, PNPushType pushType, bool sendQueryParams){
            string channel = "push_channel";
            string uuid = "customuuid";
            Dictionary<string,string> queryParams = new Dictionary<string, string>();
            string queryParamString = "";
            if(sendQueryParams){
                queryParams.Add("d","f");
                queryParamString="&d=f";
            } else {
                queryParams = null;
            }


            PNConfiguration pnConfiguration = new PNConfiguration ();
            pnConfiguration.Origin = EditorCommon.Origin;
            pnConfiguration.SubscribeKey = EditorCommon.SubscribeKey;
            pnConfiguration.PublishKey = EditorCommon.PublishKey;
            pnConfiguration.Secure = ssl;
            pnConfiguration.CipherKey = "enigma";
            pnConfiguration.LogVerbosity = PNLogVerbosity.BODY; 
            pnConfiguration.PresenceTimeout = 60;
            pnConfiguration.PresenceInterval= 30;
            pnConfiguration.UUID = uuid;
            pnConfiguration.AuthKey = authKey;

            PubNubUnity pnUnity = new PubNubUnity(pnConfiguration, null, null);

            string authKeyString = "";
            if (!string.IsNullOrEmpty(authKey)) {
                authKeyString = string.Format ("&auth={0}", pnConfiguration.AuthKey);
            }

            Uri uri = BuildRequests.BuildRemoveChannelPushRequest (channel, pushType, pushToken, pnUnity, queryParams);
            //[1, "Modified Channels"]
            //http://ps.pndsn.com/v1/push/sub-key/demo-36/devices/pushToken?remove=push_channel&type=mpns&uuid=customuuid&auth=authKey&pnsdk=PubNub-CSharp-UnityIOS/3.6.9.0
            string expected = string.Format ("http{0}://{1}/v1/push/sub-key/{2}/devices/{3}?remove={4}&type={5}&uuid={6}{7}&pnsdk={8}{9}",
                ssl?"s":"", pnConfiguration.Origin, EditorCommon.SubscribeKey, pushToken, 
                Utility.EncodeUricomponent(channel, PNOperationType.PNRemovePushNotificationsFromChannelsOperation, true, false), pushType.ToString().ToLower(),
                uuid, authKeyString, 
                Utility.EncodeUricomponent(pnUnity.Version, PNOperationType.PNRemovePushNotificationsFromChannelsOperation, false, true),
                queryParamString
            );
            string received = uri.OriginalString;
            UnityEngine.Debug.Log("exp:"+expected);
            UnityEngine.Debug.Log(received);
            EditorCommon.LogAndCompare (expected, received);
        }

        [Test]
        public void TestBuildGetChannelsPushRequestAPNS ()
        {
            TestBuildGetChannelsPushRequestCommon (true, "", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void TestBuildGetChannelsPushRequestMPNS ()
        {
            TestBuildGetChannelsPushRequestCommon (true, "", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void TestBuildGetChannelsPushRequestGCM ()
        {
            TestBuildGetChannelsPushRequestCommon (true, "", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void TestBuildGetChannelsPushRequestAPNSAuth ()
        {
            TestBuildGetChannelsPushRequestCommon (true, "authKey", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void TestBuildGetChannelsPushRequestMPNSAuth ()
        {
            TestBuildGetChannelsPushRequestCommon (true, "authKey", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void TestBuildGetChannelsPushRequestGCMAuth ()
        {
            TestBuildGetChannelsPushRequestCommon (true, "authKey", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void TestBuildGetChannelsPushRequestSSLAPNS ()
        {
            TestBuildGetChannelsPushRequestCommon (false, "", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void TestBuildGetChannelsPushRequestSSLMPNS ()
        {
            TestBuildGetChannelsPushRequestCommon (false, "", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void TestBuildGetChannelsPushRequestSSLGCM ()
        {
            TestBuildGetChannelsPushRequestCommon (false, "", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void TestBuildGetChannelsPushRequestSSLAPNSAuth ()
        {
            TestBuildGetChannelsPushRequestCommon (false, "authKey", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void TestBuildGetChannelsPushRequestSSLMPNSAuth ()
        {
            TestBuildGetChannelsPushRequestCommon (false, "authKey", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void TestBuildGetChannelsPushRequestSSLGCMAuth ()
        {
            TestBuildGetChannelsPushRequestCommon (false, "authKey", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void TestBuildGetChannelsPushRequestSSLGCMAuthQP ()
        {
            TestBuildGetChannelsPushRequestCommon (false, "authKey", "pushToken", PNPushType.GCM, true);
        }

        public void TestBuildGetChannelsPushRequestCommon(bool ssl, string authKey, string pushToken, PNPushType pushType){
            TestBuildGetChannelsPushRequestCommon(ssl, authKey, pushToken, pushType, false);
        }

        public void TestBuildGetChannelsPushRequestCommon(bool ssl, string authKey, string pushToken, PNPushType pushType, bool sendQueryParams){
            string uuid = "customuuid";
            Dictionary<string,string> queryParams = new Dictionary<string, string>();
            string queryParamString = "";
            if(sendQueryParams){
                queryParams.Add("d","f");
                queryParamString="&d=f";
            } else {
                queryParams = null;
            }
            PNConfiguration pnConfiguration = new PNConfiguration ();
            pnConfiguration.Origin = EditorCommon.Origin;
            pnConfiguration.SubscribeKey = EditorCommon.SubscribeKey;
            pnConfiguration.PublishKey = EditorCommon.PublishKey;
            pnConfiguration.Secure = ssl;
            pnConfiguration.CipherKey = "enigma";
            pnConfiguration.LogVerbosity = PNLogVerbosity.BODY; 
            pnConfiguration.PresenceTimeout = 60;
            pnConfiguration.PresenceInterval= 30;
            pnConfiguration.UUID = uuid;
            pnConfiguration.AuthKey = authKey;

            PubNubUnity pnUnity = new PubNubUnity(pnConfiguration, null, null);

            string authKeyString = "";
            if (!string.IsNullOrEmpty(authKey)) {
                authKeyString = string.Format ("&auth={0}", pnConfiguration.AuthKey);
            }

            Uri uri = BuildRequests.BuildGetChannelsPushRequest (pushType, pushToken, pnUnity, queryParams);

            //[1, "Modified Channels"]
            //["push_channel"]
            //https://ps.pndsn.com/v1/push/sub-key/demo-36/devices/pushToken?type=wns&uuid=customuuid&auth=authKey&pnsdk=PubNub-CSharp-UnityIOS/3.6.9.0
            //https://ps.pndsn.com/v1/push/sub-key/demo-36/devices/pushToken?type=mpns&uuid=customuuid&auth=authKey&pnsdk=PubNub-CSharp-UnityIOS/3.6.9.0
            string expected = string.Format ("http{0}://{1}/v1/push/sub-key/{2}/devices/{3}?type={4}&uuid={5}{6}&pnsdk={7}{8}",
                ssl?"s":"", pnConfiguration.Origin, EditorCommon.SubscribeKey, pushToken, 
                pushType.ToString().ToLower(),
                uuid, authKeyString, 
                Utility.EncodeUricomponent(pnUnity.Version, PNOperationType.PNPushNotificationEnabledChannelsOperation, false, true),
                queryParamString
            );
            string received = uri.OriginalString;
            UnityEngine.Debug.Log("exp:"+expected);
            UnityEngine.Debug.Log(received);
            EditorCommon.LogAndCompare (expected, received);
        }

        [Test]
        public void BuildUnregisterDevicePushRequestAPNS ()
        {
            BuildUnregisterDevicePushRequestCommon (true, "", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void BuildUnregisterDevicePushRequestMPNS ()
        {
            BuildUnregisterDevicePushRequestCommon (true, "", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void BuildUnregisterDevicePushRequestGCM ()
        {
            BuildUnregisterDevicePushRequestCommon (true, "", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void BuildUnregisterDevicePushRequestAPNSAuth ()
        {
            BuildUnregisterDevicePushRequestCommon (true, "authKey", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void BuildUnregisterDevicePushRequestMPNSAuth ()
        {
            BuildUnregisterDevicePushRequestCommon (true, "authKey", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void BuildUnregisterDevicePushRequestGCMAuth ()
        {
            BuildUnregisterDevicePushRequestCommon (true, "authKey", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void BuildUnregisterDevicePushRequestSSLAPNS ()
        {
            BuildUnregisterDevicePushRequestCommon (false, "", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void BuildUnregisterDevicePushRequestSSLMPNS ()
        {
            BuildUnregisterDevicePushRequestCommon (false, "", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void BuildUnregisterDevicePushRequestSSLGCM ()
        {
            BuildUnregisterDevicePushRequestCommon (false, "", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void BuildUnregisterDevicePushRequestSSLAPNSAuth ()
        {
            BuildUnregisterDevicePushRequestCommon (false, "authKey", "pushToken", PNPushType.APNS);
        }

        [Test]
        public void BuildUnregisterDevicePushRequestSSLMPNSAuth ()
        {
            BuildUnregisterDevicePushRequestCommon (false, "authKey", "pushToken", PNPushType.MPNS);
        }

        [Test]
        public void BuildUnregisterDevicePushRequestSSLGCMAuth ()
        {
            BuildUnregisterDevicePushRequestCommon (false, "authKey", "pushToken", PNPushType.GCM);
        }

        [Test]
        public void BuildUnregisterDevicePushRequestSSLGCMAuthQP ()
        {
            BuildUnregisterDevicePushRequestCommon (false, "authKey", "pushToken", PNPushType.GCM, true);
        }

        public void BuildUnregisterDevicePushRequestCommon(bool ssl, string authKey, string pushToken, PNPushType pushType){
            BuildUnregisterDevicePushRequestCommon(ssl, authKey, pushToken, pushType, false);
        }

        public void BuildUnregisterDevicePushRequestCommon(bool ssl, string authKey, string pushToken, PNPushType pushType, bool sendQueryParams){
            string uuid = "customuuid";
            Dictionary<string,string> queryParams = new Dictionary<string, string>();
            string queryParamString = "";
            if(sendQueryParams){
                queryParams.Add("d","f");
                queryParamString="&d=f";
            } else {
                queryParams = null;
            }

            PNConfiguration pnConfiguration = new PNConfiguration ();
            pnConfiguration.Origin = EditorCommon.Origin;
            pnConfiguration.SubscribeKey = EditorCommon.SubscribeKey;
            pnConfiguration.PublishKey = EditorCommon.PublishKey;
            pnConfiguration.Secure = ssl;
            pnConfiguration.CipherKey = "enigma";
            pnConfiguration.LogVerbosity = PNLogVerbosity.BODY; 
            pnConfiguration.PresenceTimeout = 60;
            pnConfiguration.PresenceInterval= 30;
            pnConfiguration.UUID = uuid;
            pnConfiguration.AuthKey = authKey;

            PubNubUnity pnUnity = new PubNubUnity(pnConfiguration, null, null);

            string authKeyString = "";
            if (!string.IsNullOrEmpty(authKey)) {
                authKeyString = string.Format ("&auth={0}", pnConfiguration.AuthKey);
            }

            Uri uri = BuildRequests.BuildUnregisterDevicePushRequest (pushType, pushToken, pnUnity, queryParams);
            //[1, "Removed Device"]
            //https://ps.pndsn.com/v1/push/sub-key/demo-36/devices/pushToken/remove?type=wns&uuid=customuuid&auth=authKey&pnsdk=PubNub-CSharp-UnityIOS/3.6.9.0
            string expected = string.Format ("http{0}://{1}/v1/push/sub-key/{2}/devices/{3}/remove?type={4}&uuid={5}{6}&pnsdk={7}{8}",
                ssl?"s":"", pnConfiguration.Origin, EditorCommon.SubscribeKey, pushToken, 
                pushType.ToString().ToLower(),
                uuid, authKeyString, 
                Utility.EncodeUricomponent(pnUnity.Version, PNOperationType.PNRemoveAllPushNotificationsOperation, false, true),
                queryParamString
            );
            string received = uri.OriginalString;
            UnityEngine.Debug.Log("exp:"+expected);
            UnityEngine.Debug.Log(received);
            EditorCommon.LogAndCompare (expected, received);
        }
        

        #endif
    }
}

