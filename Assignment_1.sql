
CREATE DATABASE OurExerciseDb ON PRIMARY
(NAME = 'OurExercise_Db', FILENAME = 'D:\Assignments_phase2\Assignment1\OurExerciseDb.mdf', SIZE = 24MB, MAXSIZE = 32MB, FILEGROWTH = 8MB)
LOG ON
(NAME = 'OurExercise_log', FILENAME = 'D:\Assignments_phase2\Assignment1\OurExercise_log.ldf', SIZE = 8MB, MAXSIZE = 16MB, FILEGROWTH = 4MB)

COLLATE SQL_Latin1_General_CP1_CI_AS
use OurExerciseDb
create table StudentRegistrations
(StudentId int,
CourseCode nvarchar(50),
RegistrationDate date,
constraint pk_SR primary key(StudentId, CourseCode))
insert into StudentRegistrations values(999, 'EC304', '04/08/2023')
insert into StudentRegistrations values(998, 'EC302','08/09/2023')
insert into StudentRegistrations values(997, 'EC302','04/06/2023')
insert into StudentRegistrations values(996, 'EC301', '04/06/2023')
insert into StudentRegistrations values(999, 'EC305', '10/08/2023')
insert into StudentRegistrations values(800, 'EC201', '10/07/2023')
insert into StudentRegistrations values(801, 'EC202', '10/07/2023')
insert into StudentRegistrations values(801, 'EC203', '10/07/2023')
insert into StudentRegistrations values(804, 'EC203', '01/08/2023')
select * from StudentRegistrations