using Castle.DynamicProxy;

namespace LearnAdmin.Extensions.AOP
{
	public class LearnAdminLogLogAop: IInterceptor
	{
        public void Intercept(IInvocation invocation)
        {
            // 记录被拦截方法信息的日志信息
            var dataIntercept = $"{DateTime.Now.ToString("yyyyMMddHHmmss")} " +
                                $"当前执行方法{invocation.Method.Name} " +
                                $"参数是{String.Join("，", invocation.Arguments.Select(a => (a ?? "").ToString())).ToArray()}";


            // 注意，下边方法仅仅是针对同步的策略，如果你的service是异步的，这里获取不到
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                dataIntercept += $"方法执行中出现异常：{ex.Message}";
            }
            dataIntercept += $"被拦截方法执行完毕，返回结果：{invocation.ReturnValue}";
            var path = Directory.GetCurrentDirectory() + @"\Log";
            if(!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            var fileName = path + $@"\InterceptLog-{DateTime.Now.ToString("yyyyMMddHHmmss")}.log";
            var sw = File.AppendText(fileName);
            sw.WriteLine(dataIntercept);
            sw.Close();
        }
	}
}

