using System;
using System.ComponentModel;
using System.Reflection;

namespace RAP.View
{
    public static class EnumString
    {
        //parse string into valid enum type value
        public static T ToEnum<T>(this string description)
        {
            return (T)Enum.Parse(typeof(T), description);
        }


        // Get corresponding enum value for description string 
        public static T EnumValue<T>(this string description)
        {
            foreach (var field in typeof(T).GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    if (attribute.Description == description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
                else if (field.Name == description)
                {
                    return (T)field.GetValue(null);
                }
            }

            return default(T);
        }

        //get corresponding description string for enum value
        public static string Description(this Enum value)
        {
            MemberInfo[] memberInfo = value.GetType().GetMember(value.ToString());

            if(memberInfo != null && memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes
                    (typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return value.ToString();
        }
    }
}
