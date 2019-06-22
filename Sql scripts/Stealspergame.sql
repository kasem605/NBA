;with player_cte ([name],teamname,stealspergame)
as
(select top 10 [name],teamname,pointspergame from stat order by stealspergame desc)
select [name],teamname,stealspergame from player_cte order by stealspergame asc
