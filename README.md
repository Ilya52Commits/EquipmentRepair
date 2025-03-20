# Программа ремонта оборудования / Equipment repair program

Разработка программного модуля для учета заявок на ремонт климатического оборудования предназначена для автоматизации процесса обработки заявок на ремонт со стороны заказчиков, а также для облегчения и ускорения работы сотрудникам, ответственным за обслуживание и ремонт климатического оборудования.
---
**Development of a program module for accounting of requests for repair of climate equipment is intended to automate the process of processing repair requests from customers, as well as to facilitate and accelerate the work of employees responsible for maintenance and repair of climate equipment.**

### Основные функции и возможности модуля включают / The main functions and features of the module include:
1. Заявка на ремонт: это информация, предоставленная заказчиком о неисправности климатического оборудования, которое требует ремонта. Заказчик оставляет новую заявку. Заявка может содержать данные о типе оборудования, модели, описании проблемы, личную информацию (ФИО клиента и номер телефона). Заказчик может отредактировать свою заявку.
2. Регистрация заявки: этот процесс включает приём и регистрацию заявки оператором сервисной службы в системе учёта. Важными аспектами регистрации являются присвоение уникального идентификатора заявке, сохранение информации о заявке.
3. Техник может зайти на страницу зарегестрированных заявок и взяться за необходиму. 
---
1. Repair request: this is the information provided by the customer about the malfunction of the climate equipment that requires repair. The customer leaves a new request. The request may contain data on the type of equipment, model, description of the problem, personal information (customer's name and phone number). The customer can edit his/her request.
2. Registration of the request: this process involves receiving and registering the request by the service operator in the accounting system. Important aspects of registration are assigning a unique identifier to the request, saving information about the request.
3. the technician can go to the page of registered requests and take up the necessary work.

### Функциональные требования / Functional requirements
1. Возможность добавления заявок в базу данных с указанием следующих параметров:
- Номер заявки;
- Дата добавления;
- Тип оборудования;
- Модель устройства;
- Описание проблемы;
- ФИО заказчика;
- Номер телефона;
- Статус заявки (открыта заявка, в процессе ремонта, завершена).
2. Возможность редактирования заявок:
- Изменение этапа выполнения (завершена, в процессе ремонта, ожидание комплектующих);
- Изменение описания проблемы.
3. Возможность отслеживания статуса заявки:
- Отображение списка заявок;
- Поиск заявки по номеру.
---
1. Ability to add applications to the database with the following parameters:
- Application number;
- Date of addition;
- Equipment type;
- Device model;
- Description of the problem;
- Customer Name;
- Phone number;
- Status of the request (open request, in the process of repair, completed).
2. Ability to edit requests:
- Changing the stage of fulfillment (completed, in the process of repair, waiting for components);
- Change of problem description.
3. Ability to track request status:
- Displaying a list of requests;
- Search for a request by number.
  
Программа реализует паттерн MVVM и сервисную архитектуру. Содаржит два типа GUI: с помощью WPF и AvaloniaUI.
Может взаимодействовать с MS SQL и PostgreSQL. Для того, чтобы переключаться между базами, необходимо в файле appsettings.json в EquipmentRepairWPF или EquipmentRepairAvaloniaUI в "DataProvider" указать "MsSql" для MSSQL и "PgSql" для PostgreSQL.
---
**The program implements MVVM pattern and service architecture. It contains two types of GUI: using WPF and AvaloniaUI.
It can interact with MS SQL and PostgreSQL. In order to switch between databases, you need to specify “MsSql” for MSSQL and “PgSql” for PostgreSQL in “DataProvider” in the file appsettings.json in EquipmentRepairWPF or EquipmentRepairAvaloniaUI.
**
