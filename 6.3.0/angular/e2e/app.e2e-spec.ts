import { TodoAppTemplatePage } from './app.po';

describe('TodoApp App', function() {
  let page: TodoAppTemplatePage;

  beforeEach(() => {
    page = new TodoAppTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
