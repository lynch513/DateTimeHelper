namespace DateTimeHelper

open System

type TimeZone =
| UTC
| MSK
| EKB

module TimeZone =

    let private makeTimeZone (timeZone: TimeZone) =
        match timeZone with
        | UTC -> TimeZoneInfo.Utc
        | MSK -> TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time")
        | EKB -> TimeZoneInfo.FindSystemTimeZoneById("Ekaterinburg Standard Time")

    let convertFromUtcDateTime (toTimeZone: TimeZone) (utcDateTime: DateTime) =
        let timeZoneInfo = makeTimeZone toTimeZone
        TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZoneInfo)

    let convertFromLocalDateTime (toTimeZone: TimeZone) (dateTime: DateTime) =
        let fromTimeZoneInfo = TimeZoneInfo.Local
        let toTimeZoneInfo = makeTimeZone toTimeZone
        TimeZoneInfo.ConvertTime(dateTime, fromTimeZoneInfo, toTimeZoneInfo)

    let convertDateTime (fromTimeZone: TimeZone) (toTimeZone: TimeZone) (dateTime: DateTime) =
        let fromTimeZoneInfo = makeTimeZone fromTimeZone
        let toTimeZoneInfo = makeTimeZone toTimeZone
        TimeZoneInfo.ConvertTime(dateTime, fromTimeZoneInfo, toTimeZoneInfo)

    let convertDateTimeOffset (toTimeZone: TimeZone) (dateTimeOffset : DateTimeOffset) =
        let toTimeZoneInfo = makeTimeZone toTimeZone
        TimeZoneInfo.ConvertTime(dateTimeOffset, toTimeZoneInfo)
