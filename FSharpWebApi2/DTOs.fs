module DTOs
[<CLIMutable>]
type CustomerInfoDto = {
    FirstName : string
    LastName : string
    EmailAddress : string
    }
[<CLIMutable>]
type OrderFormDto = {
    OrderId : string
    CustomerInfo : CustomerInfoDto
    //ShippingAddress : AddressDto
    //BillingAddress : AddressDto
    //Lines : OrderFormLineDto list
    }