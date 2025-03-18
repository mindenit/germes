using Germes.NureNET.Parsers;
using Germes.NureNET.Parsers.Repair;
using Germes.NureNET.Types;

namespace Germes.NureNET;

public static class Cist
{
    public static List<Auditory>? GetAuditories()
    {
        try
        {
            return NureParser.ParseAuditories();
        }
        catch (Exception e)
        {
            throw new Exception("Error while getting auditories", e);
        }
    }

    public static string GetAuditories(bool AsCist)
    {
        try
        {
            return NureParser.ParseAuditories(AsCist);
        }
        catch (Exception e)
        {
            throw new Exception("Error while getting auditories", e);
        }
    }
    
    public static List<Group>? GetGroups()
    {
        try
        {
            return NureParser.ParseGroups();
        }
        catch (Exception e)
        {
            throw new Exception("Error while getting groups", e);
        }
    }

    public static string GetGroups(bool AsCist)
    {
        try
        {
            return NureParser.ParseGroups(AsCist);
        }
        catch (Exception e)
        {
            throw new Exception("Error while getting groups", e);
        }
    }
    
    public static List<Teacher>? GetTeachers()
    {
        try
        {
            return NureParser.ParseTeachers();
        }
        catch (Exception e)
        {
            throw new Exception("Error while getting teachers", e);
        }
    }

    public static string GetTeachers(bool AsCist)
    {
        try
        {
            return NureParser.ParseTeachers(AsCist);
        }
        catch (Exception e)
        {
            throw new Exception("Error while getting teachers", e);
        }
    }
    
    public static List<Event>? GetEvents( EventType type, long id, long startTime = 0, long endTime = 0)
    {
        var json = JsonFixers.TryFix(Requests.GetEventsJson(type, id));
        var Auditories = GetAuditories();

        if (startTime == 0 && endTime == 0)
        {
            var events = NureParser.ParseEvents(json);

            foreach (var e in events)
            {
                if (e.Auditory.Name is not null or "")
                {
                    e.Auditory = Auditories?.Find(x => x.Name == e.Auditory.Name);
                }
                else
                {
                    e.Auditory = new Auditory();
                }
            }
            
            return events;
        }
        else
        {
            var events = NureParser.ParseEvents(json);
            foreach (var e in events)
            {
                if (e.Auditory.Name is not null or "")
                {
                    e.Auditory = Auditories?.Find(x => x.Name == e.Auditory.Name);
                }
                else
                {
                    e.Auditory = new Auditory();
                }
            }
            return events.Where(e => e.StartTime >= startTime && e.EndTime <= endTime).ToList();
        }
    }
}