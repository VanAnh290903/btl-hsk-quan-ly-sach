/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [smanv]
      ,[stennv]
      ,[sgioitinh]
      ,[ituoi]
      ,[ssdt]
  FROM [QLS].[dbo].[tblnhanvien]
  -- tajo view xem danh sasch nhaan vien
  create view v_DSNV
  as
 select smanv as[Mã nhân viên], stennv as[Tên nhân viên],
 sgioitinh as[Giới tính], ituoi as[Tuổi], ssdt as [Số điện thoại]
 from tblnhanvien