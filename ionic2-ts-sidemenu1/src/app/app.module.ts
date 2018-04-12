import { NgModule, ErrorHandler } from '@angular/core';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { MyApp } from './app.component';
import { components } from './app.modules-base';
import { RestAPIService } from '../providers/rest-api-service';

import { SMQEndpoints } from '../providers/sassymq/smq.endpoints';
import { AppState } from '../app/app.state';
import { AppConfig } from '../app/app.config';

components.push(MyApp);

@NgModule({
  declarations: components,
  imports: [
    IonicModule.forRoot(MyApp)
  ],
  bootstrap: [IonicApp],
  entryComponents: components,
  providers: [{ provide: ErrorHandler, useClass: IonicErrorHandler }, RestAPIService, SMQEndpoints, AppState, AppConfig ]
})
export class AppModule {}
