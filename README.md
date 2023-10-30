Database Connection Details

To access the file stored in the PostgreSQL database, you will need the following database connection details:

- **Server/Host**: [localhost]
- **Port**: [7262]
- **Database Name**: [vineetrai]
- **Username**: [vineetrai]
- **Password**: [vineet@2004]


## Database Design and Data Import

- **Database Used**: PostgresSQL Server
- **Tables Created**: Raw_Bank_Transaction, Bank_Transaction
- **Data Import**: Data from CSV files was successfully imported into the Raw_Bank_Transaction table.

## REST API Implementation

I have implemented a REST API using .NET that provides the following functionalities:

### 1. List Data from Raw_Bank_Transaction (GET)

- Endpoint: /api/[controller]/GetRawBankTrans
- Description: This API endpoint retrieves data from the Raw_Bank_Transaction table.

### 2. List Data from Bank_Transaction (GET)

- Endpoint: /api/[controller]/GetBankTrans
- Description: This API endpoint retrieves data from the Bank_Transaction table.

### 3. Add Data into Raw_Bank_Transaction (POST)

- Endpoint: /api/[controller]/SaveRawBankTran
- Description: This API endpoint allows you to add data into the Raw_Bank_Transaction table using a POST request.

### 4. Delete Data from Raw_Bank_Transaction (DELETE)

- Endpoint: /api/[controller]/DeleteOrder/{id}
- Description: This API endpoint lets you delete data from the Raw_Bank_Transaction table by specifying the ID in a DELETE request.

### 5. Update Data in Raw_Bank_Transaction (PUT)

- Endpoint: /api/[controller]/UpdateRawBankTran
- Description: This API endpoint enables you to update data in the Raw_Bank_Transaction table using a PUT request.

## Logging

- I have implemented logging using the Serilog library to track necessary information and errors in the application. Log messages are structured to provide detailed insights into the system's behavior.

Thank you for your time and attention to this project.

I would Love to receive feedback and suggestion.


