# MyCoreMvc

Things that need to be done:

Deployment:
[ ] Deployment on linux server (Install .net Core Mvc on linus, build application, run application on linus, setup Httpd with Core Mvc application)
[ ] Setup Production, Testing and Development environments (database structure, assets)

Security:
[ ] Security (authentication and identification, create SSL certificate, setup TLS)
[ ] Multi factor authentication
[ ] Third party authentication
[ ] Protection for XSS attacks by using/implementing the equivalent of Rails authentication_token
[ ] Implement sand for passwords to protect against rainbow attacks
 
Layout:
[ ] Create basic layout using twitter.bootstrap (Navigation, Default pages, Header, Footer, Columns, Theme)

Generic Functionality:
[ ] Photo uploading and cropping
[ ] Define and assign user claims (roles)
[ ] Send email
[ ] Push notifications (Websockets)
[ ] AJAX requests
[ ] notifications, alerts, messages

Authentication Functionality
[X] User sign up, login 
[ ] Request password reset
[X] Configure sign-in manager, create authentication token and authentication cookie
[X] Create email verification token and create verification controller
[ ] Create/send email 
[ ] Create password reset token, create/send email create reset controller and form, resend reset password email
[X] Create overview of users and add Delete functionality
[ ] Handle error messages
[ ] Create user messages, notifications, alerts, warnings
[ ] Create layout for user messages using Bootstrap

Specific Functionality:
[X] CRUD blog (index, new, create, edit, update, delete), layout
[ ] Implement Model validations
[ ] CRUD comments
[X] implement routing
[ ] implement routing tags for forms

Database stucture:
[ ] Setup CRUD operations
[ ] Understand how does linking of objects work (Ruby has_many equivalent)
[ ] Understand how is inheritance handled in database structure?
[ ] When objects are stored while held in the context of their parent object, how does EF handle this?


EF operations
Add-Migration Initial -Context ApplicationDbContext
Update-Database -Context ApplicationDbContext

Identity Dependencies:
Microsoft.Extensions.Cconfiguration
Microsoft.Extensions.Cconfiguration.Json
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools





