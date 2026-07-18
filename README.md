                        API Gateway
                             │
                             │
                   Admission.Api
                             │
                  Tenant Middleware
                             │
               ITenantResolver Service
                             │
          +------------------+-------------------+
          |                                      |
 HTTP Header                         JWT Claim
 X-Tenant-ID                         TenantId
          |                                      |
          +------------------+-------------------+
                             │
                             ▼
                    Tenant Database
                    (Master Database)
                             │
          +------------------+--------------------+
          |                  |                    |
     Tenant A           Tenant B            Tenant C
     Connection         Connection          Connection
       String             String              String
          |                  |                    |
          +------------------+--------------------+
                             │
                  DbContext Factory
                             │
                   AdmissionDbContext
                             │
                     SQL Server Database
