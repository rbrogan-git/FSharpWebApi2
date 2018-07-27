module DTOs
open Domain
open Common.Types
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
// ======================================================
// Override the SimpleType constructors 
// so that they raise exceptions rather than return Results
// ======================================================

let failOnError aResult =
    match aResult with
    | Ok success -> success 
    | Error error -> failwithf "%A" error



module EmailAddress =
    let create fieldName = EmailAddress.create fieldName >> failOnError
module CustomerInfoDto =
    type ValidateCustomer =
        OrderFormDto -> Result<ValidatedCustomer,ValidationError list>
    let validateCustomer  customerInfoDto  =
        let validEmail = customerInfoDto.EmailAddress |> EmailAddress.create "EmailAddress"
        let cust =
            { FName = customerInfoDto.FirstName
              LName = customerInfoDto.LastName
              Email = validEmail
            }
        cust