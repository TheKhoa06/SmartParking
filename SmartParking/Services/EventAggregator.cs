using System;
using SmartParking.Models;

namespace SmartParking.Services
{
    public static class EventAggregator
    {
        // Event fired when a parking slot status changes (Huân's map updates)
        public static event Action<int, int, string?>? SlotStatusChanged;

        // Event fired when a session checks in or checks out (Vinh's dashboard & Huân's map update)
        public static event Action<ParkingSession>? SessionUpdated;

        // Event fired when pricing rules are updated by Hưng (Khoa's gate reloads pricing)
        public static event Action? PricingRulesUpdated;

        // Event fired when a monthly card is created, updated or renewed by Hưng
        public static event Action? MonthlyCardUpdated;

        public static void PublishSlotStatusChanged(int slotId, int newStatus, string? plate)
        {
            SlotStatusChanged?.Invoke(slotId, newStatus, plate);
        }

        public static void PublishSessionUpdated(ParkingSession session)
        {
            SessionUpdated?.Invoke(session);
        }

        public static void PublishPricingRulesUpdated()
        {
            PricingRulesUpdated?.Invoke();
        }

        public static void PublishMonthlyCardUpdated()
        {
            MonthlyCardUpdated?.Invoke();
        }
    }
}
