import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { HttpClient, provideHttpClient, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { ExceptionInterceptor } from './interceptors/ExceptionInterceptor';

export const appConfig: ApplicationConfig = {
  
  providers: [
    provideHttpClient(withInterceptors([ExceptionInterceptor])),
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideRouter(routes)
  ]
};
