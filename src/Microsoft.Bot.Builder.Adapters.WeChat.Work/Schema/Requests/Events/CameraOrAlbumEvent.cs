﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml.Serialization;

namespace Microsoft.Bot.Builder.Adapters.WeChat.Work.Schema.Requests.Events
{
    [XmlRoot("xml")]
    public class CameraOrAlbumEvent : RequestEventWithEventKey
    {
        public override string EventType => EventTypes.CameraOrAlbum;

        [XmlElement(ElementName = "SendPicsInfo")]
        public SendPicsInfo SendPicsInfo { get; set; }
    }
}
