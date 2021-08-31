﻿namespace Architect.Dto.EventBus
{
    public class EventBusSettings
    {
        public bool AzureServiceBusEnabled { get; set; }
        public string EventBusConnection { get; set; }
        public string EventBusUserName { get; set; }
        public string EventBusPassword { get; set; }
        public int EventBusRetryCount { get; set; }
        public string EventBusBrokerName { get; set; }
        public string SubscriptionClientName { get; set; }
    }
}
