// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Bot.Builder.Adapters.WeChat.Work.Schema.Requests.Events
{
    public interface IRequestMessageEventBase : IRequestMessageBase
    {
        string EventType { get; }
    }
}
