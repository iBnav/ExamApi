# API - Generate and validate token 

This API generate and validate tokens from a card number and customer. 

## Routes

### api/card
#### Method: POST
Save a customer card number and generate a valid token for 30 minutes.
#### Body request parameters:
``` json
{
    "customer_id": int,
    "card_number": long,
    "cvv": int
}
```
#### Responses: 
Success: 200 OK
```
{
    "registration_date": datetime UTC,
    "token": long,
    "card_id": int
}
```
Invalid parameter: 422 Unprocessable Entity
```
string with which invalid parameter
```
---
### api/token
#### Method: POST
Validate token
#### Body request parameters:
``` json
{
    "customer_id": int,
    "token": long,
    "cvv": int,
    "card_id": int
}
```
#### Responses: 
Success: 200 OK
```
{
    "validated": bool
}
```