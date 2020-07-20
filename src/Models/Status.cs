using System;

namespace ZarinPalDriver.Models
{
    public struct Status : IEquatable<Status>
    {
        public static readonly Status Success = new Status(100);

        public Status(int code)
        {
            Code = code;

            Message = EvaluateCode(code);
        }

        private static string EvaluateCode(int code)
        {
            switch (code)
            {
                case -9:
                    {
                        return "خطای اعتبار سنجی";
                    }
                case -10:
                    {
                        return "ای پی و يا مرچنت كد پذيرنده صحيح نيست";
                    }
                case -11:
                    {
                        return "مرچنت کد فعال نیست لطفا با تیم پشتیبانی ما تماس بگیرید";
                    }
                case -12:
                    {
                        return "تلاش بیش از حد در یک بازه زمانی کوتاه.";
                    }
                case -15:
                    {
                        return "ترمینال شما به حالت تعلیق در آمده با تیم پشتیبانی تماس بگیرید";
                    }
                case -16:
                    {
                        return "سطح تاييد پذيرنده پايين تر از سطح نقره اي است.";
                    }
                case -30:
                    {
                        return "اجازه دسترسی به تسویه اشتراکی شناور ندارید";
                    }
                case -31:
                    {
                        return "حساب بانکی تسویه را به پنل اضافه کنید مقادیر وارد شده واسه تسهیم درست نیست";
                    }
                case -32:
                    {
                        return "Wages is not valid, Total wages(floating) has been overload max amount.";
                    }
                case -33:
                    {
                        return "درصد های وارد شده درست نیست";
                    }
                case -34:
                    {
                        return "مبلغ از کل تراکنش بیشتر است";
                    }
                case -35:
                    {
                        return "تعداد افراد دریافت کننده تسهیم بیش از حد مجاز است";
                    }
                case -40:
                    {
                        return "Invalid extra params, expire_in is not valid.";
                    }
                case -50:
                    {
                        return "مبلغ پرداخت شده با مقدار مبلغ در وریفای متفاوت است";
                    }
                case -51:
                    {
                        return "پرداخت ناموفق";
                    }
                case -52:
                    {
                        return "خطای غیر منتظره با پشتیبانی تماس بگیرید";
                    }
                case -53:
                    {
                        return "اتوریتی برای این مرچنت کد نیست";
                    }
                case -54:
                    {
                        return "اتوریتی نامعتبر است";
                    }
                case 100:
                    {
                        return "عملیات موفق";
                    }
                case 101:
                    {
                        return "تراکنش وریفای شده";
                    }
                default:
                    {
                        throw new ArgumentException("Status code is invalid or not registered.");
                    }
            }
        }

        public int Code { get; }

        public string Message { get; }

        public static bool operator ==(Status left, Status right)
        {
            return left.Code == right.Code;
        }

        public static bool operator !=(Status left, Status right)
        {
            return !(left == right);
        }

        public bool Equals(Status other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is Status status)
            {
                return Equals(status);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }

        public override string ToString()
        {
            return $"{Code}|{Message}";
        }
    }
}
