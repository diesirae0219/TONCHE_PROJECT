using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonChe_Operation_Cneter.Database
{
    public class SQL_TEXT
    {

        public static string Q_ART_CNT = @"SELECT COUNT(1) CNT FROM  ART_BASIC ";
        public static string Q_EMPL = @"SELECT *  FROM  tbaemploy AS t WHERE   (remark2 = 'SYS') ";

        public static string I_NEW_ART = "insert into ART_BASIC (ART_NO,CONSTRUCTION,COMPOSITION,WEIGHT,REMARK,COLOR,PRICE,ART_TYPE)  " +
        "    values (@ART_NO, @CONSTRUCTION, @COMPOSITION,@WEIGHT,@REMARK,@COLOR ,@PRICE ,@ART_TYPE) ";

        public static string Q_REASON_CODE = @"SELECT REASON_CODE, REASON_MARK,REASON_PT
            FROM      INS_REASON order by REASON_CODE";
        public static string Q_INSPECT_BY_ART_EQP = @"SELECT  * FROM      INS_MAIN
            where EQP_NO=':eqp'
            and ART_NO = ':art_no'
            and substring(INS_NO,1,8) = ':dt'
            order by INS_NO desc
            ";
        public static string I_NEW_INS_MAIN = @"insert into INS_MAIN(
        INS_NO,            ART_NO,        EQP_NO,        LENGTH,        PTS,        GRADE,        REMARK,            SPONSOR  ,   LENGTH_OUTPUT,grp     )VALUES
        (        ':INS_NO',          ':ART_NO',        ':EQP_NO',        ':LENGTH',        ':PTS',        ':GRADE',        ':REMARK',
              ':SPONSOR'  ,':OPLENGTH' ,':GRP'     )";

        public static string I_NEW_INS_DETAIL_OUTPUT_1 = @"insert into INS_DETAIL_OUTPUT
        (INS_NO,SHIFT,GRP,sYard,eYard) ";

        public static string I_NEW_INS_DETAIL_OUTPUT_2 = @"SELECT  ':INS_NO',':SHIFT',':GRP',':sYard',':eYard' ";

        public static string I_NEW_INS_DETAIL_1 = @"insert into INS_DETAIL(
        INS_NO,CHK_PT,REASON_CODE,REMARK,SHIFT,PTS,GRP)  ";
        public static string I_NEW_INS_DETAIL_2 = @"  SELECT  ':INS_NO',':CHK_PT',':REASON_CODE',':REMARK',':SHIFT',':PTS' ,':GRP' ";

        public static string I_C_SEL_1 = @"insert into C_SELECTION(
        CID,CUSTOMER_NAME,ART_NO,REMARK,SEQ)  ";
        public static string I_C_SEL_2 = @"  SELECT  ':CID',':CUSTOMER_NAME',':ART_NO',':REMARK' ,':SEQ'";

        public static string Q_SAERCH_INS = @"     select INS_NO,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12,PTS,GRADE,LENGTH,LENGTH_OUTPUT ,SPONSOR FROM (
            SELECT INS_NO,GRADE,SPONSOR,PTS,LENGTH,LENGTH_OUTPUT,
            [1] as 'C1',[2] as 'C2',[3] as 'C3',[4]as 'C4',[5] as 'C5',[6] as 'C6',[7] as 'C7',[8] as 'C8',[9] as 'C9',[10]as 'C10',[11]as 'C11',[12] as 'C12'
            FROM
            (
		   SELECT a.INS_NO+'_'+a.GRP INS_NO,a.GRADE,a.SPONSOR,a.PTS,a.LENGTH_OUTPUT,a.LENGTH,b.CHK_PT+'_'+c.REASON_MARK+'_'+b.PTS PP,
			ROW_NUMBER ( )  OVER (  PARTITION BY  a.INS_NO+'_'+a.GRP order by CASE ISNUMERIC( b.CHK_PT) WHEN 1 THEN CAST( b.CHK_PT AS float) ELSE null end   ) as R
                FROM INS_MAIN a, INS_DETAIL b,INS_REASON c where a.INS_NO = b.INS_NO
	            and b.REASON_CODE = c.REASON_CODE AND c.REASON_CODE <> '0'   
				and a.grp = b.grp
                and a.INS_NO between ':dt1%' and ':dt2%'
	            ) AS INS_DETAIL
            PIVOT
            (
            MAX(PP)
            FOR R IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])
            ) AS PivotTable
            )AS FIN ";

        public static string Q_SEARCH_INS_SUMMARY = @"
        select B.grade,a.LENGTH from (
        select a.grade,
              sum(CASE ISNUMERIC( a.LENGTH_output) WHEN 1 THEN CAST( a.LENGTH_output AS float) ELSE null end )LENGTH
                    from  INS_MAIN a , INS_DETAIL b , INS_REASON c
                where a.INS_NO = b.INS_NO
                and b.REASON_CODE = c.REASON_CODE
                and a.ins_no between ':dt1%' and ':dt2%'
             --   and a.grade = 'A'
                group by a.grade
		        )A right join (	select 'A' grade union all select 'B' union all select 'C' ) B
		        on A.grade = B.grade
        ";

        public static string Q_SAERCH_INS_OUTPUT = @" 
            select t.INS_NO+'_'+t.GRP INS_NO ,t.SHIFT,t.sYard,t.eYard from INS_DETAIL_OUTPUT t
            where t.INS_NO  between ':dt1%' and ':dt2%' ";

        public static string Q_INS_DATA = @"
        SELECT SUBSTRING ( a.INS_NO ,5 ,2 ) +'/' +SUBSTRING ( a.INS_NO ,7 ,2 )+'/'+SUBSTRING ( a.INS_NO ,1 ,4 )DATE  , 
        a.INS_NO,a.EQP_NO,a.ART_NO,a.GRADE,a.PTS,a.REMARK,a.SPONSOR,a.LENGTH,b.CHK_PT,b.PTS,b.REASON_CODE,b.REMARK D_REMARK,b.SHIFT,a. LENGTH_OUTPUT
          FROM INS_MAIN a, INS_DETAIL b
          where a.INS_NO = b.INS_NO
          and a.INS_NO = ':INS_NO' 
          order by   CASE ISNUMERIC( b.CHK_PT) WHEN 1 THEN CAST( b.CHK_PT AS float) ELSE null end     
        ";

        public static string D_INS_MAIN = @"DELETE FROM INS_MAIN where ins_NO = ':INS_NO' ";

        public static string D_INS_DETAIL = @"DELETE FROM INS_DETAIL where ins_NO = ':INS_NO' ";

        public static string D_INS_DETAIL_OUTPUT = @"DELETE FROM INS_DETAIL_OUTPUT where ins_NO = ':INS_NO' ";


        public static string Q_EQP_ERROR = @"select a.EQP_NO+'('+MAX(b.REASON_CODE+'-'+c.REASON_MARK)+')' R,count(1) CNT from  INS_MAIN a , INS_DETAIL b , INS_REASON c
        where a.INS_NO = b.INS_NO
        and b.REASON_CODE = c.REASON_CODE
        and c.REASON_CODE <> '0'
        and a.ins_no between ':dt1%' and ':dt2%' 
        group by a.EQP_NO";

        public static string Q_GRADE_SUMMARY_A = @"select convert(datetime, substring(a.INS_NO,1,8), 112)  DT,
      sum(CASE ISNUMERIC( a.LENGTH) WHEN 1 THEN CAST( a.LENGTH AS float) ELSE null end )LENGTH
            from  INS_MAIN a , INS_DETAIL b , INS_REASON c
        where a.INS_NO = b.INS_NO
        and b.REASON_CODE = c.REASON_CODE
        and a.ins_no between ':dt1%' and ':dt2%'
        and a.grade = 'A'
        group by convert(datetime, substring(a.INS_NO,1,8), 112) ";

        public static string Q_GRADE_SUMMARY_B = @"select convert(datetime, substring(a.INS_NO,1,8), 112)  DT, sum(CASE ISNUMERIC( a.LENGTH) WHEN 1 THEN CAST( a.LENGTH AS float) ELSE null end )LENGTH
            from  INS_MAIN a , INS_DETAIL b , INS_REASON c
        where a.INS_NO = b.INS_NO
        and b.REASON_CODE = c.REASON_CODE
        and a.ins_no between ':dt1%' and ':dt2%'
        and a.grade = 'B'
        group by convert(datetime, substring(a.INS_NO,1,8), 112) ";

        public static string Q_GRADE_SUMMARY_C = @"select convert(datetime, substring(a.INS_NO,1,8), 112)  DT, sum(CASE ISNUMERIC( a.LENGTH) WHEN 1 THEN CAST( a.LENGTH AS float) ELSE null end )LENGTH
            from  INS_MAIN a , INS_DETAIL b , INS_REASON c
        where a.INS_NO = b.INS_NO
        and b.REASON_CODE = c.REASON_CODE
        and a.ins_no between ':dt1%' and ':dt2%'
        and a.grade = 'C'
        group by convert(datetime, substring(a.INS_NO,1,8), 112) ";

        public static string Q_EQP = @"            
        SELECT EQP_ID ,EQP_STATUS ,EQP_TYPE ,BEAM_TYPE ,LAST_PM_DATE ,LAST_STOP_DATE
        FROM EQP";

        public static string Q_INS_MAIN = @"SELECT  INS_NO, CLAIM_TIME, ART_NO, EQP_NO, LENGTH, PTS, GRADE, REMARK, REC_TIME, SPONSOR, 
        LENGTH_OUTPUT
        FROM      INS_MAIN t
        where t.INS_NO = ':INS_NO' ";

        public static string Q_INS_MAIN_DISTINCT = @"select distinct INS_NO,ART_NO,EQP_NO,LENGTH from INS_MAIN t 
        where t.INS_NO like ':d1%' ";

        public static string Q_INS_MAIN_OUTPUT = @"
        select  t1.ART_NO,t1.EQP_NO,t1.LENGTH,t1.SPONSOR,t1.remark,t1.out_SHIFT,t1.grade,t1.LENGTH_OUTPUT,t1.PTS,t2.*  from INS_MAIN t1  , INS_DETAIL_OUTPUT t2
        where t1.INS_NO = ':INS_NO'
        and t1.INS_NO = t2.INS_NO
        and t1.grp = t2.grp
        ";

        public static string Q_INS_MAIN_REASON = @"
            select t1.ART_NO,t1.EQP_NO,t1.LENGTH,t1.SPONSOR,t1.remark,t1.grade,t1.LENGTH_OUTPUT,t1.PTS,t1.out_SHIFT,t2.*
            from INS_MAIN t1  , INS_DETAIL t2
            where t1.INS_NO = ':INS_NO'
            and t1.INS_NO = t2.INS_NO
            and t1.grp = t2.grp";


        public static string Q_EQPSummary =@"
SELECT [DATE]      ,[SHIFT]      ,[EQP_ID]      ,[PROD_ID]      ,[RPM]      ,[WD]      ,[ACT_QTY]      ,[QTY]
,[G3]      ,[G4]      ,[G5]      ,[I1]      ,[I2]      ,[REMARK]      ,[SUM_ACT_QTY]      ,[SUM_QTY]
FROM [TonChe].[dbo].[tbEQP_QTY] t
where t.date between '2017-03-01' and '2017-03-31'
order by date";

        public static string Q_EQPSummary_By_Date = @"
        SELECT 
        DATE ,ROUND(AVG(ACT_QTY/((RPM*40/WD)/3)*100),2)EFF,SUM(ACT_QTY) SUM_QTY,round(sum(SUM_ACT_QTY*I1*I2)/3,0) EARNED
        FROM tbEQP_QTY t
        where t.date between '2017-03-01' and '2017-03-31'
        group by date";


        public static string Q_STOCK_HISTORY = @"
        SELECT UPDATE_TIME '更新日期' , case 
		when  t1.UPDATE_REASON like '%-1' then '倉庫'
		when t1.UPDATE_REASON like '%-2' then '布架'
		when t1.UPDATE_REASON like '%-H' then '吊卡分類'
		when t1.UPDATE_REASON like '%-S' then '布卡分類'
		when t1.UPDATE_REASON like '%-E' then '展覽分類'
		else null end '位置/分類' ,t1.STK_NAME '位置編號' , SUBSTRING (t1.update_reason,1, CHARINDEX('-', update_reason)-1 ) '調整原因'  ,
       t1.QTY '最後數量' ,t1.QTY_MODIFY '調整數量' 
         , (select  emplname from tbaemploy where emplno =UPDATE_USER ) '更新者'
          FROM ART_STK_HISTORY    t1
            where t1.art_no = ':ART_NO' order by UPDATE_TIME desc";

        public static string Q_LAST_STOCK_HISTORY = @"

        select 	case 
		when  t.UPDATE_REASON like '%-1' then '倉庫'
		when t.UPDATE_REASON like '%-2' then '布架'
		when t.UPDATE_REASON like '%-H' then '吊卡分類'
		when t.UPDATE_REASON like '%-S' then '布卡分類'
		when t.UPDATE_REASON like '%-E' then '展覽分類'
		else null end '位置/分類' , t.* from ART_STK_HISTORY t where ART_NO+convert(varchar, UPDATE_TIME, 113) +UPDATE_REASON  in (
        SELECT ART_NO+MAX(convert(varchar, UPDATE_TIME, 113)+UPDATE_REASON )    
          FROM ART_STK_HISTORY t1 where t1.art_no = ':ART_NO'
          group by ART_NO,UPDATE_REASON
          )

        ";

        public static string Q_STK_DEF = @"select * from STK_DEF";

        public static string Q_ART_TYPE = "select * from ART_TYPE order by NO ";

        public static string I_STK_HIS = @"insert into ART_STK_HISTORY(
        ART_NO,STK_NAME,QTY,UPDATE_REASON,UPDATE_USER,RMK  ,QTY_MODIFY )VALUES
        (':ART_NO',':STK_NAME',':QTY',':UPDATE_REASON',':UPDATE_USER',':RMK' ,':QTY_MODIFY')";

        public static string Q_PROD_SEARCH = @"SELECT ART_NO, CONSTRUCTION, COMPOSITION, WEIGHT, REMARK, COLOR, PRICE, WEFT_DENSE, COST, WARP_M, 
        SH_RATE, REMARK2, AFT, ART_TYPE
        FROM   ART_BASIC t ";

    }
}
