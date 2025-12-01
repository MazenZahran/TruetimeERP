Public Class EmployeesOhdaList
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT O.[ID]
      ,[EmployeeNo]
      ,I.ItemName  
      ,[OnDate]
      ,O.[Notes]
      ,[OhdahStatus]
	  ,E.EmployeeName
	  ,O.OnDate,O.OhdahStatus
  FROM [dbo].[EmployeesOhdah] O
  left join EmployeesData E on E.EmployeeID=O.EmployeeNo
  left join EmployeesItems I on I.ItemNo=O.ItemNo  "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        Me.GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub EmployeesOhdaList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub GetVocationsDataForEmployee(_Date As Date, _EmpID As Integer, _VocationType As Integer)
        Dim sqlstring As String
        sqlstring = "    Declare @Date date	;   Declare @EmpID int   Declare @VocationType int ;
                           Set @Date='" & Format(_Date, "yyyy-MM-dd") & "' ;  Set @EmpID=" & _EmpID & " ;   Set @VocationType=" & _VocationType & "

                           Declare @Year int; ; Set @Year=datepart(year,@Date)
                           SELECT EmpID,EmployeeName,DateOfStart,ISNULL(AllAddningBalances,0)-ISNULL (AllVocations,0) as balance,IsNull(VocationType,1) As VocationType,
                                  ISNULL( THISYEARVOCATIONS,0) as THISYEARVOCATIONS , ISNULL( ThisYearSetBalance ,0) as ThisYearSetBalance,
                                  ISNULL (AllAddningBalances-AllVocations+THISYEARVOCATIONS-ThisYearSetBalance,0) as BeginingBalance                     
                           FROM 
                                 (  
			                         ( Select EmployeeID AS EmpID ,EmployeeName,DateOfStart From EmployeesData  where [Active] = 1 GROUP BY EmployeeID,EmployeeName,DateOfStart) SS		
	                                                Left Join
			                         (  Select VocationType, EmployeeID AS Employe , ISNULL( AllAddningBalances,0) as AllAddningBalances  From EmployeesData  left join (  Select   SUM(BalanceDays) AS AllAddningBalances , Employee, VocationType   From [VacationsBalancesAdding]   where VocationType = 1 and [BalanceDate] <  Concat(@Year,'-','12','-','31')    group by Employee,VocationType     ) aa    on aa.Employee = EmployeeID  ) DSA		       
	                                                on SS.EmpID = DSA.Employe
	                                                Left Join 	 
			                         ( Select bb.EmployeeID AS Employee , ISNULL(AllVocations,0) as AllVocations From EmployeesData bb  left join ( Select  ISNULL( SUM(NoDays),0)  AS AllVocations,EmployeeID From [Vocations] where VocationType = 1 And FromDate <  Concat(@Year,'-','12','-','31')   group by EmployeeID    ) aa    on aa.EmployeeID = bb.EmployeeID  ) DSS
	                                                on SS.EmpID =DSS.Employee 
	                                                Left Join 

			                         ( Select bb.EmployeeID AS EmployeeID , ISNULL(THISYEARVOCATIONS,0) as THISYEARVOCATIONS From EmployeesData bb  left join (Select  ISNULL( SUM(NoDays),0)  AS THISYEARVOCATIONS,EmployeeID From [Vocations]  where VocationType = 1 and FromDate BETWEEN Concat(@Year,'-','01','-','01')  AND Concat(@Year,'-','12','-','31')  GROUP BY EmployeeID  ) aa    on aa.EmployeeID = bb.EmployeeID) BB
	                                                ON SS.EmpID=BB.EmployeeID
	                                                Left Join 
	
	                                 ( Select bb.EmployeeID AS Emp , ISNULL(ThisYearSetBalance,0) as ThisYearSetBalance From EmployeesData bb  left join ( SELECT ISNULL( SUM(BalanceDays),0)  AS ThisYearSetBalance , Employee From [VacationsBalancesAdding]  where  VocationType = 1 and [BalanceDate] between  Concat(@Year,'-','12','-','31')  and Concat(@Year,'-','12','-','31')  group by Employee  ) aa    on aa.Employee = bb.EmployeeID  ) as RERE  
	                                                ON SS.EmpID =RERE.Emp
                                 )  "
    End Sub
End Class