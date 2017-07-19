using System;

using System.Collections.Generic;
using UnityEngine;

namespace PubNubAPI
{
    public class RemoveChannelsFromGroupRequestBuilder: PubNubNonSubBuilder<RemoveChannelsFromGroupRequestBuilder, PNChannelGroupsRemoveChannelResult>, IPubNubNonSubscribeBuilder<RemoveChannelsFromGroupRequestBuilder, PNChannelGroupsRemoveChannelResult>
    {      
        public RemoveChannelsFromGroupRequestBuilder(PubNubUnity pn):base(pn){

        }
        
        #region IPubNubBuilder implementation

        public void Async(Action<PNChannelGroupsRemoveChannelResult, PNStatus> callback)
        {
            this.Callback = callback;
            Debug.Log ("RemoveChannelsFromGroupRequestBuilder Async");
            base.Async(callback, PNOperationType.PNRemoveChannelsFromGroupOperation, CurrentRequestType.NonSubscribe, this);
        }
        #endregion

        protected override void RunWebRequest(QueueManager qm){
            RequestState<PNChannelGroupsRemoveChannelResult> requestState = new RequestState<PNChannelGroupsRemoveChannelResult> ();
            requestState.RespType = PNOperationType.PNRemoveChannelsFromGroupOperation;
            
            /*Uri request = BuildRequests.BuildTimeRequest(
                this.PubNubInstance.PNConfig.UUID,
                this.PubNubInstance.PNConfig.Secure,
                this.PubNubInstance.PNConfig.Origin,
                this.PubNubInstance.Version
            );

            this.PubNubInstance.PNLog.WriteToLog(string.Format("RunTimeRequest {0}", request.OriginalString), PNLoggingMethod.LevelInfo);
            base.RunWebRequest(qm, request, requestState, this.PubNubInstance.PNConfig.NonSubscribeTimeout, 0, this);*/
        }

        protected override void CreatePubNubResponse(object deSerializedResult){
            /*Int64[] c = deSerializedResult as Int64[];
            PNTimeResult pnTimeResult = new PNTimeResult();
            PNStatus pnStatus = new PNStatus();
            if ((c != null) && (c.Length > 0)) {
                
                pnTimeResult.TimeToken = c [0];
                pnStatus.Error = false;
            } else {
                pnStatus.Error = true;
            }
            Callback(pnTimeResult, pnStatus);*/
        }
        
    }
}

