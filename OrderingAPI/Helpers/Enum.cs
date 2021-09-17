using System.Collections.Generic;

namespace OrderingAPI.Helpers
{
    public class Enum
    {

    }
    public enum HttpAttribute
{
    GET,
    POST,
    PUT

}

public enum WebHookCallBackMethods
{
    StoresAddUpdate,
    StoreActions,
    CatalogueIngestion,
    CategoryTimingGroup,
    ItemActions,
    OptionActions,
    OrderRelay,
    OrderStatusChange,
    RiderStatusChange

}

public enum WebHookEvent
{
    all,
    order_placed,// order placed event.
    order_status_update,// order state change event.
    rider_status_update,// rider state change event.
    inventory_update,// callback url for managing catalogue call.
    store_creation,// callback url for store creation call.
    store_action,// event for callback url for Store Actions API call.
    item_state_toggle,// event for callback url for items actions done through Item/Option - actions API call.
    catalogue_timing_grp,// event for callback url for Category Timing Groups API.
    option_state_toggle,// event for callback url for option actions done through Item/Option - actions API call.
    hub_menu_publish,// event for callback url for menu publish to aggregators.
    order_items_oos_processed,// event for callback url for mark order item out-of-stock
}
}