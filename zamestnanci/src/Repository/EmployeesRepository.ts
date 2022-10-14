import IEmployees from '@/Models/IEmployees';
import http from './Http'

class EmployeesRepository {

  getAll(): Promise<any> {
    return http.get("api/employees/archived/false");
  }
  
  getArchived(): Promise<any> {
    return http.get("api/employees/archived/true");
  }
  delete(employeeId: number): Promise<any> {
    return http.delete(`api/employees/${employeeId}`);
  }

  getId(employeeId: number): Promise<any> {
    return http.get('api/employees/' + employeeId);
  }

  archive(employeeId: number, data: any): Promise<any> {
    return http.put("/archive/" + employeeId, data)

  }

  Edit(id: number, data: any): Promise<any> {
    return http.put("api/employees/" + id, data);
  }

  Post(data: any): Promise<any> {
    return http.post("api/employees/", data);
  }

}
export default new EmployeesRepository();