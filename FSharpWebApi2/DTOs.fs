namespace DTOs
open Domain
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
type ValidationError = {
    FieldName : string
    ErrorDescription : string
    }

module CustomerInfoDto =
    type ValidateCustomer =
        OrderFormDto -> Result<ValidatedCustomer,ValidationError list>
    let validateCustomer  customerInfoDto  =
        let cust =
            { FName = customerInfoDto.FirstName
              LName = customerInfoDto.LastName
              Email = customerInfoDto.EmailAddress
            }
        cust