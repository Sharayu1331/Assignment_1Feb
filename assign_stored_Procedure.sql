USE [WFA3dotnet]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertEmp]    Script Date: 01/02/2021 10:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_InsertEmp]
   @ename varchar(30),
   @sal float,
   @dno int

   as 
   begin
   insert into EmployeeTab(Ename,salary,DeptNo)
   values(@ename,@sal,@dno)
   end

   use WFA3dotnet

   create proc sp_InsertDetails
   @empname varchar(20),
   @esal float,
   @deptId int

   as
   begin
   insert into EmployeeTab(Ename,salary,DeptNo) values(@empname,@esal,@deptId)
   end

   exec sp_InsertDetails 'sharman',776.5,12

   select * from EmployeeTab

   create proc sp_DeleteDetails
   @eid int
   
   as
   begin

   delete from EmployeeTab
   where eid = @eid
   end

   exec sp_DeleteDetails 4

   select * from EmployeeTab

   create proc sp_SearchForDetails
   @eid int
   as
   begin
   select ee.eid,ee.ename,ee.salary,de.deptName
   from EmployeeTab ee
   join DeptTab de
   on ee.DeptNo = de.DeptId
   where eid = @eid
   end

   exec sp_SearchForDetails 5