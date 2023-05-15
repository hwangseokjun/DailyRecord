using DailyRecord.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecord.Models
{
    public class DirectoryNode
    {
        private ObservableCollection<DirectoryNode> _directoryChildren;

        public int RecordId { get; set; }
        public string Name { get; set; }
        public ObservableCollection<DirectoryNode> DirectoryChildren
        {
            get
            {
                if (_directoryChildren is null) 
                {
                    LoadChildren();
                }

                return _directoryChildren;
            }
            set => _directoryChildren = value;
        }

        private void LoadChildren() 
        {
            /* TODO: 해당지점에서 데이터베이스 조회 필요. 가장 먼저 찾은 1개의 데이터를 넣어준다.
             * 트리뷰 펼치기 동작시에는 데이터를 삭제한 후 다시 찾아와 바인딩 해준다. 이 때, 비동기 처리를 해준다.
             */
            // 현재는 테스트용 객체 사용
            _directoryChildren = new ObservableCollection<DirectoryNode>() { new DirectoryNode { Name = "TEST" } };
        }
    }
}
