namespace Composite
{
    internal class Implementation
    {
        internal abstract class FileSystemItem
        {
            private readonly string name;
            public FileSystemItem(string name) => this.name = name;

            public abstract long GetSize();
        }

        internal class File : FileSystemItem
        {
            private readonly long size;
            public File(string name, long size) : base(name) => this.size = size;

            public override long GetSize() => size;
        }

        internal class Directory : FileSystemItem
        {
            private readonly IList<FileSystemItem> fileSystemItems;
            private readonly long size;
            public Directory(string name, long size) : base(name)
            {
                this.size = size;
                fileSystemItems = new List<FileSystemItem>();
            }

            public void Add(FileSystemItem itemToAdd) => fileSystemItems.Add(itemToAdd);

            public void Remove(FileSystemItem itemToRemove) => fileSystemItems.Remove(itemToRemove);    
            public override long GetSize()
            {
                var treeSize = size;
                foreach (var fileSystemItem in fileSystemItems)
                {
                    treeSize += fileSystemItem.GetSize();
                }

                return treeSize;
            }
        }
    }
}
