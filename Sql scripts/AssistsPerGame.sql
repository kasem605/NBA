;with player_cte ([name],teamname,assistspergame)
as
(select top 10 [name],teamname,assistspergame from stat order by assistspergame desc)
select [name],teamname,assistspergame from player_cte order by assistspergame asc