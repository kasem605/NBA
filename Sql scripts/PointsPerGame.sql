;with player_cte ([name],teamname,pointspergame)
as
(select top 10 [name],teamname,pointspergame from stat order by pointspergame desc)
select [name],teamname,pointspergame from player_cte order by pointspergame desc
